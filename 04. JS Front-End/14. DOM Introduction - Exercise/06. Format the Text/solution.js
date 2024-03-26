function solve() {
  const inputAreaElement = document.getElementById("input");
  const outputAreaElement = document.getElementById("output");

  let sentencesArray = inputAreaElement.value
    .split(".")
    .filter((sentence) => sentence.trim() !== "")
    .map((sentence) => sentence.trim() + ".");

  if (sentencesArray.length <= 3) {
    outputAreaElement.innerHTML = `<p>${sentencesArray.join(" ")}</p>`;
  } else {
    let paragraphs = [];
    for (let i = 0; i < sentencesArray.length; i += 3) {
      paragraphs.push(`<p>${sentencesArray.slice(i, i + 3).join(" ")}</p>`);
    }
    outputAreaElement.innerHTML = paragraphs.join("");
  }
}
