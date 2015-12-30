/**
 * Created by Sujith on 12/14/2015.
 */
function addHeader()
{
            var header = document.getElementById('header');
            if(header)
            {
                var header_contents = read_contents("MasterPage_Contents/Header_Contents");
                if(header_contents)
                {
                    place_in_outerHTML(header,header_contents);
                }
            }
}