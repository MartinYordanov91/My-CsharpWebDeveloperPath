const baseUrl = "http://localhost:3030/jsonstore/gifts";

const giftElement = document.getElementById("gift");
const forElement = document.getElementById("for");
const priceElement = document.getElementById("price");

const buttonEditPressentElement = document.getElementById("edit-present");
buttonEditPressentElement.disabled = true;

const buttonAddPressentElement = document.getElementById("add-present");
buttonAddPressentElement.addEventListener("click", () => {
  if (!giftElement.value || !forElement.value || !priceElement.value) {
    return;
  }

  fetch(baseUrl, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({
      gift: giftElement.value,
      for: forElement.value,
      price: priceElement.value,
    }),
  }).then((res) => {
    loadAllPressonts();
    giftElement.value = "";
    forElement.value = "";
    priceElement.value = "";
  });
});

const buttonLoadPressentsElement = document.getElementById("load-presents");
buttonLoadPressentsElement.addEventListener("click", () => {
  loadAllPressonts();
});

const divPressentsListElement = document.getElementById("gift-list");

function createHtmlDivSock(pressent) {
  const divSockElement = document.createElement("div");
  divSockElement.classList.add("gift-sock");

  const divContentElement = document.createElement("div");
  divContentElement.classList.add("content");

  const pPrisent = document.createElement("p");
  pPrisent.textContent = pressent.gift;

  const pFor = document.createElement("p");
  pFor.textContent = pressent.for;

  const pPrice = document.createElement("p");
  pPrice.textContent = pressent.price;

  const divButtonElement = document.createElement("div");
  divButtonElement.classList.add("buttons-container");

  const buttonChange = document.createElement("button");
  buttonChange.classList.add("change-btn");
  buttonChange.textContent = "Change";

  buttonChange.addEventListener("click", () => {
    divPressentsListElement.removeChild(divSockElement);

    giftElement.value = pressent.gift;
    forElement.value = pressent.for;
    priceElement.value = pressent.price;

    buttonAddPressentElement.disabled = true;
    buttonEditPressentElement.disabled = false;
    buttonEditPressentElement.addEventListener("click", () => {
      if (!giftElement.value || !forElement.value || !priceElement.value) {
        return;
      }

      fetch(`${baseUrl}/${pressent._id}`, {
        method: "PUT",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          gift: giftElement.value,
          for: forElement.value,
          price: priceElement.value,
        }),
      }).then((res) => {
        loadAllPressonts();
        giftElement.value = "";
        forElement.value = "";
        priceElement.value = "";
        buttonAddPressentElement.disabled = false;
        buttonEditPressentElement.disabled = true;
      });
    });
  });

  const buttonDelete = document.createElement("button");
  buttonDelete.classList.add("delete-btn");
  buttonDelete.textContent = "Delete";

  buttonDelete.addEventListener("click", () => {
    fetch(`${baseUrl}/${pressent._id}`, {
      method: "DELETE",
    }).then((res) => {
      loadAllPressonts();
    });
  });

  divPressentsListElement.appendChild(divSockElement);
  divSockElement.appendChild(divContentElement);
  divSockElement.appendChild(divButtonElement);
  divContentElement.appendChild(pPrisent);
  divContentElement.appendChild(pFor);
  divContentElement.appendChild(pPrice);
  divButtonElement.appendChild(buttonChange);
  divButtonElement.appendChild(buttonDelete);
}

function loadAllPressonts() {
  fetch(baseUrl)
    .then((res) => res.json())
    .then((pressents) => {
      divPressentsListElement.innerHTML = "";

      Object.values(pressents).forEach((pressent) => {
        createHtmlDivSock(pressent);
      });
    });
}
