function attachEvents() {
  const baseUrl = `http://localhost:3030/jsonstore/phonebook`;

  const listPhonebookElement = document.getElementById("phonebook");
  const InputPersonNameElement = document.getElementById(`person`);
  const InputPersonPhoneElement = document.getElementById(`phone`);
  const buttonLoadPhonesElement = document.getElementById(`btnLoad`);
  const buttonCreatePhonesElement = document.getElementById(`btnCreate`);

  buttonLoadPhonesElement.addEventListener("click", loadPoneBook);
  buttonCreatePhonesElement.addEventListener("click", createNewContact);

  function loadPoneBook() {
    fetch(baseUrl)
      .then((res) => res.json())
      .then((phones) => {
        Object.values(phones).map((phone) => {
          loadContact(phone);
        });
      });
  }

  function createNewContact() {
    const person = InputPersonNameElement.value;
    const phone = InputPersonPhoneElement.value;
    const contact = { person, phone };

    fetch(baseUrl, {
      method: "POST",
      headers: {
        "content-Type": "application/json",
      },
      body: JSON.stringify(contact),
    })
      .then((res) => res.json())
      .then((newContact) => loadContact(newContact));
  }

  function loadContact({ person, phone, _id }) {
    const liElement = document.createElement("li");
    const buttonElement = document.createElement("button");
    liElement.textContent = `${person}: ${phone}`;
    buttonElement.textContent = "Delete";

    buttonElement.addEventListener("click", () =>
      deliteElement(_id, liElement)
    );

    listPhonebookElement.appendChild(liElement);
    liElement.appendChild(buttonElement);
  }

  function deliteElement(contactId, liElement) {
    fetch(`${baseUrl}/${contactId}`, {
      method: "DELETE",
    });

    listPhonebookElement.removeChild(liElement);
  }
}

attachEvents();
