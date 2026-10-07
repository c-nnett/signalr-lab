document.getElementById("button").addEventListener("click", async () => {
    try {
        const message = document.getElementById('messageInput').value;
        const user = localStorage.getItem("user");
        await connection.invoke("SendMessage", user, message);
    } catch (err) {
        console.error(err);
    }
})

connection.on("ReceiveMessage", (user, message) => {
    const li = document.createElement("li");
    li.textContent = `${user}: ${message}`;
    document.getElementById("messageList").appendChild(li);
})