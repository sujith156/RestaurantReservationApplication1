/**
 * Created by Sujith on 12/22/2015.
 */

function  addFooter()
{
    if(document.getElementById)
    {
        var footer = document.getElementById('footer');
        if(footer)
        {
            var footer_contents = read_contents("MasterPage_Contents/Footer_contents");
            if(footer_contents)
            {
                place_in_outerHTML(footer,footer_contents);

            }
        }
    }

}