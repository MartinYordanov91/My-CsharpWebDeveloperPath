function toUperText(text) {
  let textArray = text
    .toUpperCase()
    .match(/[a-zA-Z0-9]+/g)
    .filter((w) => w.length >= 1)
    .join(", ");

  console.log(textArray);
}

toUperText("Hi, how are you?");
toUperText("hello");
toUperText("!w< ,,dsa,ds08adas,,  985?? ,das!");
