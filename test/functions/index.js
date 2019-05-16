const functions = require('firebase-functions');
const firebase = require('firebase-admin');
const express = require('express');


var config = {
    apiKey: "AIzaSyDqee9L7UQ8o9VgUOl9bR57HX2YLnVPQTo",
    authDomain: "citydefender-5ffdd.firebaseapp.com",
    databaseURL: "https://citydefender-5ffdd.firebaseio.com",
    projectId: "citydefender-5ffdd",
    storageBucket: "citydefender-5ffdd.appspot.com",
    messagingSenderId: "93830636438",
};


const app = express();
const firebaseApp = firebase.initializeApp(config);



function getHighScores() {


    const ref = firebaseApp.database().ref('highscores/');

    return ref.once('value').then(snap => snap.val());

}

app.get('/timestamp', (request, response) => {

    response.send(`${Date.now()}`);
});

app.get('/timestamp-cached', (request, response) => {


    response.set('Cache-Control', 'public, max-age = 300, s-maxage=600');
    response.send(`${Date.now()}`);
});


app.get('/highscore', (request, response) => {


    response.set('Cache-Control', 'public, max-age = 300, s-maxage=600');

    getHighScores().then(scores => {

        response.json(scores);

    })
});

exports.app = functions.https.onRequest(app);
