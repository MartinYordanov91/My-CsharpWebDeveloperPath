function solve() {
  let inputText = document
    .getElementById("text")
    .value.split(" ")
    .map((x) => x.toLowerCase())
    .map((word) => {
      return word.charAt(0).toUpperCase() + word.slice(1);
    });

  let inputComand = document.getElementById("naming-convention").value;

  let resultElement = document.getElementById("result");

  if (inputComand === "Pascal Case") {

    resultElement.innerHTML = inputText.join("");

  } else if (inputComand === "Camel Case") {
    
    let word = inputText.shift().toLowerCase()
    inputText.unshift(word);
    resultElement.innerHTML = inputText.join("")

  } else {

    resultElement.innerHTML = "Error!";

  }
}
