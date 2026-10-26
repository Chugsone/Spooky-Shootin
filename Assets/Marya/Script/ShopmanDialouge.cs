using UnityEngine;
using TMPro;

public class ShopmanDialouge : MonoBehaviour
{
   
    public string FirstWords = "Welcome to Smokey's! Buy somethin', ya bum!";
    public string[] idle_Talk = new string[]
    {
        "I ain't got time for meddlin'! Buy something!",
        "These ol' bones darn been through more waves then you'll see in a thousand high noons."
    };

    [SerializeField] private TextMeshProUGUI ShopTalk; // controls what the shop keeper says

    
    public void Start() // for testing. please delete the start() area
    {
        ShopTalk.text = "These ol' bones darn been through more waves then you'll see in a thousand high noons.";
    }

    /* 
     Dialouge holder for dialouge that has been thought of. can be used how ever or not at all.


     "Gosh-darned kids these days!"
"I was once a hunter like ya. Yer waves ain't nuthin'."
"Pick somethin' and get out, ya meddler."
"I don't give a gosh-darn how many enemies ya  got, this what I'm sellin!"
"These ol' bones darn been through more waves then you'll see in a thousand high noons."
"Ya break it, ya bought it!"
"Welcome to Smokey's! Buy somethin', ya bum!"
"Kids these days makin' their tikky tokkies doin' the hippity-hoppity. No respect!"
"I ain't got time for meddlin'! Buy something!"
"Hurry up. I got buddies at the saloon waitin' on me."
"Best deals this side o' the graveyard."
"Damn feller, ya got that bruised over the small silly waves?!"
"I made Zomboxers run from me back in the day."
"YEEEEEE-HOOOOO! *ahem* sorry 'bout that, feller."
"I reckon my jeans need anotha hundred layers o' starch, eh?"
"I'd wipe all dem waves o' baddies for ya, but I don't feel like it."
"I've got tales aplenty. Share 'em? No."
"Am I hip with da kids if I say sixty-seven? Heheh."
"Hurry up. The horse is here."
"My offers stink? What is this, Zach's shop?! Don't get picky with me!"
"This is Smokey's SHOP, not Smokey's meddle and yap place! Buy a damn upgrade!"
"Make a sale, you bum! The bills ain't gon' pay themselves!" 
    */


    public void ShopActive()
    {

    }
}
