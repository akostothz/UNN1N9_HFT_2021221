let songs = [];
let usasongs = [];
let explicitsongs = [];
let ar7songs = [];
let connection = null;
let songIDToUpdate = -1;
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

    connection.on("SongUpdated", (user, message) => {
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
    await fetch('http://localhost:35739/stat/lovesongsfromusa')
        .then(x => x.json())
        .then(y => {
            usasongs = y;
            display();
        });
    await fetch('http://localhost:35739/stat/explicitsongsafter2010')
        .then(x => x.json())
        .then(y => {
            explicitsongs = y;
            display();
        });
    await fetch('http://localhost:35739/stat/alternativelovesongswithar7')
        .then(x => x.json())
        .then(y => {
            ar7songs = y;
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
        `<button type="button" onclick="showupdate(${t.songID})">Update</button>` +
            "</td ></tr > ";
    });
    document.getElementById('resultarea2').innerHTML = "";
    usasongs.forEach(t => {
        document.getElementById('resultarea2').innerHTML +=
            "<tr><td>" + t.songID + "</td><td>" +
            t.songName + "</td><td>" +
            t.style +
            "</td ></tr > ";
    });
    document.getElementById('resultarea3').innerHTML = "";
    explicitsongs.forEach(t => {
        document.getElementById('resultarea3').innerHTML +=
            "<tr><td>" + t.songID + "</td><td>" +
            t.songName + "</td><td>" +
            t.style +
            "</td ></tr > ";
    });
    document.getElementById('resultarea4').innerHTML = "";
    ar7songs.forEach(t => {
        document.getElementById('resultarea4').innerHTML +=
            "<tr><td>" + t.songID + "</td><td>" +
            t.songName + "</td><td>" +
            t.style +
            "</td ></tr > ";
    });
}

function showupdate(id) {
    document.getElementById('songnametoupdate').value = songs.find(t => t['songID'] == id)['songName'];
    document.getElementById('albumidtoupdate').value = songs.find(t => t['songID'] == id)['albumID'];
    document.getElementById('styletoupdate').value = songs.find(t => t['songID'] == id)['style'];
    document.getElementById('lengthtoupdate').value = songs.find(t => t['songID'] == id)['length'];
    document.querySelector('.explicittoupdate').checked = songs.find(t => t['songID'] == id)['isExplicit'];
    document.querySelector('.lovesongtoupdate').checked = songs.find(t => t['songID'] == id)['isLoveSong'];
    document.getElementById('updateformdiv').style.display = 'flex';
    songIDToUpdate = id;
}

function update() {
    document.getElementById('updateformdiv').style.display = 'none';
    let name = document.getElementById('songnametoupdate').value;
    console.log(name);
    let Style = document.getElementById('styletoupdate').value;
    console.log(Style);
    let Length = document.getElementById('lengthtoupdate').value;
    console.log(Length);
    let AlbumID = document.getElementById('albumidtoupdate').value;
    console.log(AlbumID);
    let exp = document.querySelector('.explicittoupdate').checked;
    console.log(exp);
    let love = document.querySelector('.lovesongtoupdate').checked;
    console.log(love);

    fetch('http://localhost:35739/song', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {
                songID: songIDToUpdate,
                songName: name,
                length: Length,
                style: Style,
                albumID: AlbumID,
                isExplicit: exp,
                isLoveSong: love
            }),
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

function create() {
    let name = document.getElementById('songname').value;
    console.log(name);
    let Style = document.getElementById('style').value;
    console.log(Style);
    let Length = document.getElementById('length').value;
    console.log(Length);
    let AlbumID = document.getElementById('albumid').value;
    console.log(AlbumID);
    let exp = document.querySelector('.explicit').checked;
    console.log(exp);
    let love = document.querySelector('.lovesong').checked;
    console.log(love);

    fetch('http://localhost:35739/song', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {
                songName: name,
                length: Length,
                style: Style,
                albumID: AlbumID,
                isExplicit: exp,
                isLoveSong: love
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