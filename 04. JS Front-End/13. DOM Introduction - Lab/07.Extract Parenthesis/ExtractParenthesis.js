function extract(content) {
    let text = document.getElementById("content").textContent;
  let match = /\((.*?)\)/g; 
  let matches = text.match(match);

  let extractedContent = matches.map((match) => {
    return match.substring(1, match.length - 1); 
  });
  
  return extractedContent.join("; ")
}
