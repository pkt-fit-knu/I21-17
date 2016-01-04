function Circle(x, y, radius)
{
    this.centerPoint = new Point(x, y);
    this.radius = radius;
}
            
function Point(x, y)
{
    this.x = x;
    this.y = y;
}

function Section(angle) 
{
    var element = document.createElement('div');

    element.setAttribute("class", "section");

    document.body.appendChild(element);
                
    this.element = element;
    this.targetPoint = new Point(0, 0);
    this.angle = angle;
}
            
function animateLoading(circle, section)
{
    setInterval(function()
    {
        if(section.angle < Math.PI) 
        {
            section.angle += 0.1;
        }
        else
        {
            section.angle += 0.05;
        }
                    
        if(2 * Math.PI <= section.angle)
        {
            section.angle = 0;
        }

        section.targetPoint.x = circle.centerPoint.x + Math.cos(section.angle) * circle.radius;
        section.targetPoint.y = circle.centerPoint.y + Math.sin(section.angle) * circle.radius;

        section.element.style.left = section.targetPoint.x + "px";
        section.element.style.top = section.targetPoint.y + "px";
    }, 10);
}
            
function startLoading()
{
    var circle = new Circle(650, 300, 30);
            
    var section1 = new Section(0);
    var section2 = new Section(1);
    var section3 = new Section(2);
    var section4 = new Section(3);
    var section5 = new Section(4);
                
    var sections = [section1, section2, section3, section4, section5];
				
    for(var i = 0; i < sections.length; ++i)
    {
        animateLoading(circle, sections[i]);
    }
}