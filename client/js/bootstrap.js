let user = prompt("Insira seu nome de usuário:");

if(user) {
    localStorage.setItem('user', user);
}

const connection = new signalR.HubConnectionBuilder()
    .withUrl("http://127.0.0.1:5100/chathub")
    .configureLogging(signalR.LogLevel.Information)
    .build();

async function init() {
    try {
        await connection.start();
        console.log("SinglaR Conectado");
    } catch(err) {
        console.log(err);
        setTimeout(start, 5000);
    }
}

connection.onclose(async () => {
    await start();
});

init();