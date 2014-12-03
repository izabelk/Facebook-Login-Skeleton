using Facebook;
using ImpactWorks.FBGraph.Core;
using ImpactWorks.FBGraph.Interfaces;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string title = "Test fb share";
            string url = "http://www.abv.bg";
            string summery = "Just testing psoting to fb";
            string image = "http://upload.wikimedia.org/wikipedia/commons/2/22/Turkish_Van_Cat.jpg";

            string facebooklink = "http://www.facebook.com/sharer.php?s=100&amp;p%5Btitle%5D=" + title;
            facebooklink += "&amp;p[summary]=" + summery;
            facebooklink += "&amp;p[url]=" + url;
            facebooklink += "&amp;&p[images][0]=" + image;
            lnkFacebook.HRef = facebooklink;
        }

        protected void ButtonFb_Click(object sender, EventArgs e)
        {
            CheckAuthorization();
        }

        private void CheckAuthorization()
        {
            ////Setting up the facebook object
            //ImpactWorks.FBGraph.Connector.Facebook facebook = new ImpactWorks.FBGraph.Connector.Facebook();
            //facebook.AppID = "795170443855153";
            //facebook.CallBackURL = "http://localhost:55534/Default.aspx";
            //facebook.Secret = "f378d2e335b78a7bd5da1915af0ea657";

            ////Setting up the permissions
            //List<FBPermissions> permissions = new List<FBPermissions>() {

            //    FBPermissions.read_stream,

            //    FBPermissions.publish_stream //Permission to publish on wall
            //};

            ////Pass the permissions object to facebook instance
            //facebook.Permissions = permissions;

            //if (String.IsNullOrEmpty(Request.QueryString["code"]))
            //{
            //    String authLink = facebook.GetAuthorizationLink();
            //    Response.Redirect(authLink);
            //}
            //else
            //{
            //    //Get the code returned by facebook
            //    string Code = Request.QueryString["code"];

            //    //process code for auth token
            //    facebook.GetAccessToken(Code);

            //    //Get User info
            //    FBUser currentUser = facebook.GetLoggedInUserInfo();
            //    //Image share
            //    //initiating object of type IFeedPost for posting on facebook wall
            //    IFeedPost FBpost = new FeedPost();

            //    FBpost.Caption = "Image Share";

            //    FBpost.ImageUrl = "http://www.theadway.com/wall.jpg";

            //    FBpost.Name = "Great Image";
            //    FBpost.Url = "http://www.theadway.com/wall.jpg";

            //    var postId = facebook.PostToWall(currentUser.id.GetValueOrDefault(), FBpost);

            //}


            string app_id = "795170443855153";
            string app_secret = "f378d2e335b78a7bd5da1915af0ea657";
            string scope = "publish_stream, publish_actions";

            if (Request["code"] == null)
            {
                Response.Redirect(string.Format(
                    "https://graph.facebook.com/oauth/authorize?client_id={0}&redirect_uri={1}&scope={2}",
                    app_id, Request.Url.AbsoluteUri, scope));
            }
            else
            {
                Dictionary<string, string> tokens = new Dictionary<string, string>();

                string url = string.Format("https://graph.facebook.com/oauth/access_token?client_id={0}&redirect_uri={1}&scope={2}&code={3}&client_secret={4}",
                    app_id, Request.Url.AbsoluteUri, scope, Request["code"].ToString(), app_secret);

                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;

                var response = request.GetResponse();

                //using (HttpWebResponse response = request.GetResponse() as H)
                //{
                StreamReader reader = new StreamReader(response.GetResponseStream());

                string vals = reader.ReadToEnd();

                foreach (string token in vals.Split('&'))
                {
                    //meh.aspx?token1=steve&token2=jake&...
                    tokens.Add(token.Substring(0, token.IndexOf("=")),
                        token.Substring(token.IndexOf("=") + 1, token.Length - token.IndexOf("=") - 1));
                }
                //}

                string access_token = tokens["access_token"];

                var client = new FacebookClient(access_token);

                client.Post("/me/feed", new { message = "Didi e maimunqk!" });
            }
        }
    }
}