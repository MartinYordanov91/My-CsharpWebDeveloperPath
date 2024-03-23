function solve(obj, commands) {
    for (const operation of commands) {

      if (operation.startsWith("Open")) {

        const site = operation.split("Open ")[1];
        obj["Open Tabs"].push(site);
        obj["Browser Logs"].push(operation);

      } else if (operation.startsWith("Close")) {

        const tabToClose = operation.split("Close ")[1];

        if (obj["Open Tabs"].includes(tabToClose)) {

          obj["Open Tabs"] = obj["Open Tabs"].filter(tab => tab !== tabToClose);
          obj["Recently Closed"].push(tabToClose);
          obj["Browser Logs"].push(operation);

        }

      } else if (operation.startsWith("Clear")) {

        obj["Open Tabs"] = [];
        obj["Recently Closed"] = [];
        obj["Browser Logs"] = [];
        
      }
    }
  
    console.log(obj["Browser Name"]);
    console.log(`Open Tabs: ${obj["Open Tabs"].join(", ")}`);
    console.log(`Recently Closed: ${obj["Recently Closed"].join(", ")}`);
    console.log(`Browser Logs: ${obj["Browser Logs"].join(", ")}`);
  }
  

solve(
  {
    "Browser Name": "Google Chrome",
    "Open Tabs": ["Facebook", "YouTube", "Google Translate"],
    "Recently Closed": ["Yahoo", "Gmail"],
    "Browser Logs": [
      "Open YouTube",
      "Open Yahoo",
      "Open Google Translate",
      "Close Yahoo",
      "Open Gmail",
      "Close Gmail",
      "Open Facebook",
    ],
  },
  ["Close Facebook", "Open StackOverFlow", "Open Google"]
);

solve(
  {
    "Browser Name": "Mozilla Firefox",
    "Open Tabs": ["YouTube"],
    "Recently Closed": ["Gmail", "Dropbox"],
    "Browser Logs": [
      "Open Gmail",
      "Close Gmail",
      "Open Dropbox",
      "Open YouTube",
      "Close Dropbox",
    ],
  },
  ["Open Wikipedia", "Clear History and Cache", "Open Twitter"]
);
