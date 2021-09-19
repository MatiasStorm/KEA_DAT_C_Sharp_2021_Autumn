namespace valuta 
{
    class Currency
    {
        private string code;
        private string description;
        public double Rate {get;}

        public Currency(string code, string description, double rate)
        {
            this.code = code;
            this.description = description;
            Rate = rate;
        }

        public override string ToString(){
            return code + " - " + description + " - " + Rate;
        }
    }
}
