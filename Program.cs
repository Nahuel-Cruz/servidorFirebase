// See https://aka.ms/new-console-template for more information
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;

Console.WriteLine("Hello, World!");

FirebaseApp.Create(new AppOptions()
{
    // mi clave, archivo descargado de firease @
    Credential = GoogleCredential.FromFile(@"C:\Users\Luis Nahuel\Desktop\animaciones\DotNetWithFCM\fir-598f2-firebase-adminsdk-9syay-566272f16a.json"),
});

// This registration token comes from the client FCM SDKs.
var registrationToken = "fkd3f775SA-5ymS9GwBWtI:APA91bGeHr8_KVVXJq-d2F7uipARY5KeZDHEPia-z7hPbm_QBwmWLO9AAOsSLxOnEYmo0iDK8510m1nz672jTk-xA1q1syUzvhAzxZ4Ho0glnCohqkuyN7fBhG8VXDrV-ue5eWPeqMiq";

// See documentation on defining a message payload.
var message = new Message()
{
    Data = new Dictionary<string, string>()
    {
        { "score", "850" },
        { "time", "2:45" },
    },
    Token = registrationToken,
    Notification = new Notification()
    {
        Title = "Saca",
        Body = "El servidor  ",
    }
};

// Send a message to the device corresponding to the provided
// registration token.
string response = await FirebaseMessaging.DefaultInstance.SendAsync(message);
// Response is a message ID string.
Console.WriteLine("Successfully sent message: " + response);