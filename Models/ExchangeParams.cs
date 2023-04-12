using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace CryptoAPI.Models
{
    public class ExchangeParams
    {
        [Required]
        [ValidCurrency(ErrorMessage = "Currency must be in {1}")]
        public string Currency { get; set; }
        [Required]
        [Range(1, float.MaxValue, ErrorMessage = "Please enter a value bigger than [{1}]")]
        public float Amount { get; set; }
        [Required]
        [ValidCurrencyList(ErrorMessage = "Currencies must be one or more of [{1}]")]
        public List<string> CurrenciesToExchange { get; set; }
    }

    public class ValidCurrency : ValidationAttribute
    {
        private string[] ValidCurrencies = { "btc", "eth", "ada", "bnb", "usdt" };
        public override bool IsValid(object value)
        {
            return this.ValidCurrencies.Contains(value);
        }

        public override string FormatErrorMessage(string currency)
        {
            return String.Format(CultureInfo.CurrentCulture,
              ErrorMessageString, currency, String.Join(',',this.ValidCurrencies));
        }
    }

    public class ValidCurrencyList : ValidationAttribute
    {
        private string[] ValidCurrencies = { "btc", "eth", "ada", "bnb", "usdt" };
        public override bool IsValid(object value)
        {
            return !((List<string>)value).Except(this.ValidCurrencies).Any();
        }

        public override string FormatErrorMessage(string currency)
        {
            return String.Format(CultureInfo.CurrentCulture,
              ErrorMessageString, currency, String.Join(',', this.ValidCurrencies));
        }
    }
}
