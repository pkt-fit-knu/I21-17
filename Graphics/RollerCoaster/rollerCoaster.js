var screenWidth = 1550;
var screenHeight = 850;
var step = 12;

function RollerCoaster(context) 
{ 
    var point = new Point(0, 300); 
    var increment = 0; 

    this.points = []; 
    var pointsCount = -1; 

    for(i = 0; i <= screenWidth; i += step) 
    { 
        context.moveTo(point.x, point.y); 

        point.x = i + Math.random() * step; 
        point.y = 300 - Math.sin(increment) * 200;
                        
        this.points[pointsCount++] = new Point(point.x, point.y, increment); 
                        
        increment += Math.PI * 0.07; 
                        
        context.lineTo(point.x, point.y);
        
        context.strokeStyle = 'red';
        context.lineWidth = 4;
        context.stroke(); 
    } 
} 

function Machine(speed, context, color, width) 
{ 
    this.speed = speed;
    context.strokeStyle = color;
    context.lineWidth = width;
} 

function Point(x, y, angle) 
{ 
    this.x = x; 
    this.y = y; 
    this.angle = angle; 
} 

function Run() 
{ 
    var element = document.createElement("canvas"); 
    element.setAttribute("width", screenWidth.toString()); 
    element.setAttribute("height", screenHeight.toString()); 
    document.body.appendChild(element);
    
    var context = element.getContext("2d"); 

    var rollerCoaster = new RollerCoaster(context); 
                    
    var canvasData = context.getImageData(0, 0, element.width, element.height);

    var machine = new Machine(11, context, "blue", 20); 

    var counter = -1; 

    setInterval(function() 
    { 
        if(Math.sin(rollerCoaster.points[counter].angle) != -1 || (machine.speed < -1 || machine.speed > 1))
        {
            context.putImageData(canvasData, 0, 0);
                            
            if(Math.sin(rollerCoaster.points[counter].angle) < Math.sin(rollerCoaster.points[counter + 1].angle)) 
            { 
                machine.speed -= 0.65; 
            } 
            else if(Math.sin(rollerCoaster.points[counter + 1].angle) < Math.sin(rollerCoaster.points[counter].angle)) 
            { 
                machine.speed += 0.5; 
            }

            if(machine.speed > 0) 
            { 
                ++counter; 

            } 
            else if(machine.speed <= 0) 
            { 
                --counter; 

                machine.speed += 0.15; 
            }
            
            context.beginPath();
            context.moveTo(rollerCoaster.points[counter].x, rollerCoaster.points[counter].y - 10); 
            context.lineTo(rollerCoaster.points[counter + 1].x, rollerCoaster.points[counter + 1].y - 10);
            context.stroke();
        }
    }, 75); 
}