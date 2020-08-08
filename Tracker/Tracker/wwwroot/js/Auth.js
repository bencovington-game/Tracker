

// initialize the FirebaseUI widget using Firebase.
var ui = new firebaseui.auth.AuthUI(firebase.auth());

var uiConfig = {
    callbacks: {
        signInSuccessWithAuthResult: function (authResult, redirectUrl) {
            // User successfully signed in.
            // Return type determines whether we continue the redirect automatically
            // or whether we leave that to developer to handle.
            return true;
        },
        uiShown: function () {
            // The widget is rendered.
            // Hide the loader.
            document.getElementById('loader').style.display = 'none';
        }
    },
    // will use popup for IDP Providers sign-in flow instead of the default, redirect.
    signInFlow: 'popup',
    signInSuccessUrl: 'url-to-redirect-to-on-success',
    signInOptions: [
        // leave the lines as is for the providers you want to offer your users.
        firebase.auth.EmailAuthProvider.PROVIDER_ID,
        firebase.auth.GoogleAuthProvider.PROVIDER_ID
    ],
    // Terms of service url.
    tosUrl: '<your-tos-url>',
    // privacy policy url
    privacyPolicyUrl: '<your-privacy-policy-url>'
};

ui.start('#firebaseui-auth-container', uiConfig);












//function createUser(email, password) {
//    firebase.auth().createUserWithEmailAndPassword(email, password).catch(function (error) {
//        // Handle Errors here.
//        var errorCode = error.code;
//        var errorMessage = error.message;
//        // ...
//    });
//}

//function signIn(email, password) {
//    firebase.auth().signInWithEmailAndPassword(email, password).catch(function (error) {
//        // Handle Errors here.
//        var errorCode = error.code;
//        var errorMessage = error.message;
//        // ...
//    });
//}

//function signOut() {
//    firebase.auth().signOut().then(function () {
//        // Sign-out successful.
//    }).catch(function (error) {
//        // An error happened.
//    });
//}