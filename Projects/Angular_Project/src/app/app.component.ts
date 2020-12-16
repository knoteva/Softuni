import { Component } from '@angular/core';
import * as firebase from 'firebase';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Frédéric Pinaud';

  constructor() {
    var firebaseConfig = {
      apiKey: "AIzaSyDmkmjSx1S7SZMgxZ2qfvFy1WFliWe9IyU",
      authDomain: "fredericpinaud-ae797.firebaseapp.com",
      databaseURL: "https://fredericpinaud-ae797.firebaseio.com",
      projectId: "fredericpinaud-ae797",
      storageBucket: "fredericpinaud-ae797.appspot.com",
      messagingSenderId: "517629421558",
      appId: "1:517629421558:web:821c3a5e3a8379da4b09d7",
      measurementId: "G-KCRYM2446W"
    };
    // Initialize Firebase
    firebase.initializeApp(firebaseConfig);
    firebase.analytics();  
  }
}
