function formatePhoneList(phoneList) {
  let formatedList = phoneList.reduce((acc, contakts) => {
    const [name, number] = contakts.split(" ");
    acc[name] = number;
    return acc;
  }, {});

  Object.entries(formatedList).forEach(([key, value]) =>{
    console.log(`${key} -> ${value}`);
  })
}

formatePhoneList([
  "Tim 0834212554",
  "Peter 0877547887",
  "Bill 0896543112",
  "Tim 0876566344",
]);
