function solution() {
  const listArticleUrl = `http://localhost:3030/jsonstore/advanced/articles/list`;
  const detailsArticleUrl = `http://localhost:3030/jsonstore/advanced/articles/details`;
  const mainConteiner = document.getElementById("main");

  fetch(listArticleUrl)
    .then((res) => res.json())
    .then((listsElement) => {
      const promises = listsElement.map((x) => {
        return fetch(`${detailsArticleUrl}/${x._id}`)
          .then((res) => res.json());
      });

      return Promise.all(promises);
    })
    .then((curentAcordionList) => {
      curentAcordionList.forEach((curentAcordion) => {
        createHtmlStruktores(curentAcordion);
      });
    })
    .catch((error) => {
      console.error('Error:', error);
    });

  function createHtmlStruktores({ _id, title, content }) {
    const divConteiner = document.createElement(`div`);
    divConteiner.classList.add("accordion");

    const divHeaderConteiner = document.createElement(`div`);
    divHeaderConteiner.classList.add("head");

    const divExtraConteiner = document.createElement(`div`);
    divExtraConteiner.classList.add("extra");

    const spanHeaderTitle = document.createElement("span");
    spanHeaderTitle.textContent = title;

    const buttonMoreLess = document.createElement(`button`);
    buttonMoreLess.classList.add(`button`);
    buttonMoreLess.textContent = `More`;
    buttonMoreLess.id = _id;

    buttonMoreLess.addEventListener("click", () => {
      if (divExtraConteiner.style.display === "none") {
        divExtraConteiner.style.display = "block";
        buttonMoreLess.textContent = "Less";
      } else {
        divExtraConteiner.style.display = "none";
        buttonMoreLess.textContent = "More";
      }
    });

    const pExtraConteiner = document.createElement("p");
    pExtraConteiner.textContent = content;

    divHeaderConteiner.appendChild(spanHeaderTitle);
    divHeaderConteiner.appendChild(buttonMoreLess);

    divExtraConteiner.appendChild(pExtraConteiner);

    divConteiner.appendChild(divHeaderConteiner);
    divConteiner.appendChild(divExtraConteiner);

    mainConteiner.appendChild(divConteiner);
  }
}

solution();
