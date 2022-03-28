let songs = [];
let connection = null;
getdata();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:35739/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("SongCreated", (user, message) => {
        getdata();
    });

    connection.on("SongDeleted", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    start();
}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

async function getdata() {
    await fetch('http://localhost:35739/song')
        .then(x => x.json())
        .then(y => {
            songs = y;
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    songs.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.songID + "</td><td>" +
            t.albumID + "</td><td>" +
            t.songName + "</td><td>" +
            t.style + "</td><td>" +
            t.length + "</td><td>" +
            t.isExplicit + "</td><td>" +
            t.isLoveSong + "</td><td>" +
            `<button type="button" onclick="remove(${t.songID})">Delete</button>` +
            "</td ></tr > ";
    });
}

function create() {
    let name = document.getElementById('songname').value;
    console.log(name);
    let Style = document.getElementById('style').value;
    console.log(Style);
    let Length = document.getElementById('length').value;
    console.log(Length);
    let AlbumID = document.getElementById('albumid').value;
    console.log(AlbumID);

    fetch('http://localhost:35739/song', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {
                songName: name,
                length: Length,
                style: Style,
                albumID: AlbumID
            }),
    })
        .then(response => response)
        .then(data =>
        {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) =>
        {
            console.error('Error:', error);
        });
    
}

function remove(id) {
    fetch('http://localhost:35739/song/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}