const connection = new signalR.HubConnectionBuilder()
    .withUrl("/generalHub") // SignalR Hub'ına doğru URL
    .build();

// Bağlantıyı başlatmadan önce kimliği loglamak
connection.start()
    .then(() => {
        console.log("SignalR bağlantısı başarılı. Connection ID: ", connection.connectionId);
    })
    .catch(err => {
        console.error("SignalR bağlantısı hatası: ", err);
    });

// Sunucudan gelen mesajları dinleme
connection.on("ReceiveMessage", (user, message) => {
    const li = document.createElement("li");
    li.textContent = `${user}: ${message}`;
    document.getElementById("messagesList").appendChild(li);
});

// Mesaj gönderme işlemi
document.getElementById("sendButton").addEventListener("click", () => {
    const user = document.getElementById("userInput").value;
    const message = document.getElementById("messageInput").value;

    // Sunucuya mesaj gönderme
    connection.invoke("SendMessage", user, message)
        .catch(err => {
            console.error("Mesaj gönderme hatası: ", err);
        });
});
