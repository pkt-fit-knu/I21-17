function Tree(rootColor, lowerColor, middleColor, upperColor)
{
    var parentElement = document.createElement('div');
                
    document.body.appendChild(parentElement);

    var element = document.createElement('canvas');

    element.setAttribute("width", "700");
    element.setAttribute("height", "600");
                
    parentElement.appendChild(element);
                
    var canvasContext = element.getContext("2d");
                
    canvasContext.fillStyle = rootColor;
                
    canvasContext.fillRect(335, 400, 30, 100);
                
    canvasContext.fillStyle = lowerColor;
                
    canvasContext.beginPath();
    canvasContext.moveTo(100, 400);
    canvasContext.lineTo(350, 300);
    canvasContext.lineTo(600, 400);
    canvasContext.closePath();
                
    canvasContext.fill();
                
    canvasContext.fillStyle = middleColor;
                
    canvasContext.beginPath();
    canvasContext.moveTo(150, 300);
    canvasContext.lineTo(350, 200);
    canvasContext.lineTo(550, 300);
    canvasContext.closePath();
                
    canvasContext.fill();
                
    canvasContext.fillStyle = upperColor;
                
    canvasContext.beginPath();
    canvasContext.moveTo(200, 200);
    canvasContext.lineTo(350, 100);
    canvasContext.lineTo(500, 200);
    canvasContext.closePath();
                
    canvasContext.fill();
}
            
function DrawForest()
{
    var tree1 = new Tree("#654321", "red", "blue", "#006400");
    var tree2 = new Tree("brown", "#006400", "yellow", "#DE0000");
    var tree3 = new Tree("blue", "#003234", "#006400", "yellow");
    var tree4 = new Tree("black", "purple", "#007600", "#0000FE")
}