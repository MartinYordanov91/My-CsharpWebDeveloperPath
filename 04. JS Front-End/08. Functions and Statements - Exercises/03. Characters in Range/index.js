function caracterRange(a, b) {
  let asciiCodeStart = 0;
  let asciiCodeEnd = 0;

  a.charCodeAt(0) <= b.charCodeAt(0)
    ? ((asciiCodeStart = a.charCodeAt(0)), (asciiCodeEnd = b.charCodeAt(0)))
    : ((asciiCodeStart = b.charCodeAt(0)), (asciiCodeEnd = a.charCodeAt(0)));

  const array = [];

  for (let index = asciiCodeStart + 1; index < asciiCodeEnd; index++) {
    array.push(String.fromCharCode(index));
  }

  console.log(array.join(" "));
}

caracterRange("a", "d");
caracterRange("#", ":");
caracterRange("C", "#");
