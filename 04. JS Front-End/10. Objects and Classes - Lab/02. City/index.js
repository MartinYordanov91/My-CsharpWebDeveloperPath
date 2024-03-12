function printObjInfo(obj) {
  for (const parameter in obj) {
    console.log(`${parameter} -> ${obj[parameter]}`);
  }
}

printObjInfo({
  name: "Sofia",
  area: 492,
  population: 1238438,
  country: "Bulgaria",
  postCode: "1000",
});
