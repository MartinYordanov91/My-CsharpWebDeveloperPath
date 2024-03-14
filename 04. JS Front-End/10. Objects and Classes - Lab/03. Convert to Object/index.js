function jsonParse(input) {
  input = JSON.parse(input);
  
  Object.keys(input).forEach((key) => {
    console.log(`${key}: ${input[key]}`);
  });
}

jsonParse('{"name": "George", "age": 40, "town": "Sofia"}');
