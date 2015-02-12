module cbox {

    export class Form {
        title: string;
        headlines: Headline[] = [];
        head_color: string;

        public static fromObject(obj: {}):Form {
            var f = new Form();

            f.title = obj['Title'];
            f.head_color = obj['HeadColor'];
            f.headlines = obj['Headlines'].map((h) => { return Headline.fromObject(h) }); 
             
            return f;
        }
    }

}