function attachEvents() {
  const basePostUrl = `http://localhost:3030/jsonstore/blog/posts`;
  const baseComentsUrl = `http://localhost:3030/jsonstore/blog/comments`;
  const loadButonElement = document.getElementById(`btnLoadPosts`);
  const viewButonElement = document.getElementById(`btnViewPost`);
  const selectMenuElement = document.getElementById(`posts`);
  const postHeaderTitleElement = document.getElementById("post-title");
  const postParagrafBodyElement = document.getElementById("post-body");
  const postComentsListElement = document.getElementById("post-comments");
  loadButonElement.addEventListener("click", loadMenuOptions);
  viewButonElement.addEventListener("click", printInformation);
  const postBodyArray = [];

  function printInformation() {
    while (postComentsListElement.firstChild) {
      postComentsListElement.removeChild(postComentsListElement.firstChild);
    }

    const curentSelectedOption =
      selectMenuElement.options[selectMenuElement.selectedIndex];
    postHeaderTitleElement.textContent = curentSelectedOption.textContent;

    postBodyArray.forEach(({ body, id, title }) => {
      if (id === curentSelectedOption.value) {
        postParagrafBodyElement.textContent = body;
      }
    });

    fetch(baseComentsUrl)
      .then((res) => res.json())
      .then((comments) => {
        const objectElement = Object.values(comments).map((comment) => {
          if (comment.postId === curentSelectedOption.value) {
            createComents(comment)
          }
        });
      });
  }

  function loadMenuOptions() {
    fetch(basePostUrl)
      .then((res) => res.json())
      .then((post) => {
        const objectElement = Object.values(post).map((obj) =>
          creatOptions(obj)
        );
      });
  }

  function createComents({id, postId,text }) {
    const liElement = document.createElement("li")
    liElement.textContent = text
    postComentsListElement.appendChild(liElement)
  }

  function creatOptions({ body, id, title }) {
    const optionsElement = document.createElement(`option`);
    optionsElement.value = id;
    optionsElement.textContent = title;
    selectMenuElement.appendChild(optionsElement);
    postBodyArray.push({ id, body, title });
  }
}

attachEvents();
