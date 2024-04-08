function attachEvents() {
  const messagesBaseUrl = `http://localhost:3030/jsonstore/messenger`;

  const textAreaElemnt = document.getElementById(`messages`);
  const nameInputElement = document.querySelector(`input[name=author]`);
  const messageInputElement = document.querySelector(`input[name=content]`);
  const butonSendElement = document.getElementById("submit");
  const butonRefreshElement = document.getElementById("refresh");

  butonRefreshElement.addEventListener(`click`, generateAllMessage);
  butonSendElement.addEventListener(`click`, postNewMesage);

  function generateAllMessage() {
    textAreaElemnt.value = "";
    const comentsArry = [];
    fetch(messagesBaseUrl)
      .then((res) => res.json())
      .then((messages) => {
        const messagesColections = Object.values(messages).map(
          ({ author, content }) => {
            comentsArry.push(`${author}: ${content}`);
          }
          );
          textAreaElemnt.value = comentsArry.join("\n")
      });
      
  }
  function postNewMesage() {
    const author = nameInputElement.value;
    const content = messageInputElement.value;

    if (!author || !content) {
      console.error("Author or content are mised.");
      return;
    }

    const message = { author, content };

    fetch(messagesBaseUrl, {
      method: `POST`,
      headers: {
        "content-Type": "application/json",
      },
      body: JSON.stringify(message),
    });

    nameInputElement.value = "";
    messageInputElement.value = "";
  }
}

attachEvents();
