function getSpecialWords(text) {
  let arrwords = text.match(/#[a-zA-Z]+/g).map((x) => x.slice(1));
  console.log(arrwords.join("\n"));
}

getSpecialWords(
  "Nowadays everyone uses # to tag a #special word in #socialMedia"
);
getSpecialWords(
  "The symbol # is known #variously in English-speaking #regions as the #number sign"
);
