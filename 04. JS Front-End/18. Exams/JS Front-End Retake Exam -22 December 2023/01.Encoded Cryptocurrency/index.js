// function solve([scrip, ...comands]) {
//   let message = scrip;

//   comands.forEach((comand) => {
//     const [event, ...content] = comand.split("?");

//     if (event === "TakeEven") {
//       let newMessage = "";
//       for (let index = 0; index < message.length; index += 2) {
//         newMessage += message[index];
//       }
//       message = newMessage;
//       console.log(message);
//     } else if (event === "ChangeAll") {
//       const substring = content[0];
//       const replacement = content[1];
//       const regex = new RegExp(substring, "g");

//       message = message.replace(regex, replacement);
//       console.log(message);
//     } else if (event === "Reverse") {
//       const substring = content[0];
//       if (message.includes(substring)) {
//         const regex = new RegExp(substring, "i");
//         message = message.replace(regex, "");
//         message += reverseString(substring);
//         console.log(message);
//       } else {
//         console.log("error");
//       }
//     } else if (event === "Buy") {
//       console.log(`The cryptocurrency is: ${message}`);
//     }
//   });

//   function reverseString(str) {
//     return str.split("").reverse().join("");
//   }
// }

function solve([script, ...commands]) {
  let message = script;
  commands.forEach((command) => {
    const [event, ...content] = command.split("?");
    const substring = content[0];

    switch (event) {
      case "TakeEven":
        message = message
          .split("")
          .filter((_, index) => index % 2 === 0)
          .join("");
        console.log(message);
        break;
      case "ChangeAll":
        const replacement = content[1];
        const regex = new RegExp(substring, "g");
        message = message.replace(regex, replacement);
        console.log(message);
        break;
      case "Reverse":
        if (message.includes(substring)) {
          message = message
            .replace(substring, "")
            .concat(reverseString(substring));
          console.log(message);
        } else {
          console.log("error");
        }
        break;
      case "Buy":
        console.log(`The cryptocurrency is: ${message}`);
        break;
    }
  });

  function reverseString(str) {
    return str.split("").reverse().join("");
  }
}

solve([
  "z2tdsfndoctsB6z7tjc8ojzdngzhtjsyVjek!snfzsafhscs",
  "TakeEven",
  "Reverse?!nzahc",
  "ChangeAll?m?g",
  "Reverse?adshk",
  "ChangeAll?z?i",
  "Buy",
]);

solve([
  "PZDfA2PkAsakhnefZ7aZ",
  "TakeEven",
  "TakeEven",
  "TakeEven",
  "ChangeAll?Z?X",
  "ChangeAll?A?R",
  "Reverse?PRX",
  "Buy",
]);
