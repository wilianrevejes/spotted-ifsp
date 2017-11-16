namespace Spotted {
    public class Publication {
        public string _id;
        public string content;
        public string[] likes;
        public string[] comments;

        public string PublicationID {
            get { return _id; }
        }

        public string Content {
            get { return content; }
        }
    }

}