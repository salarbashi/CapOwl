
from math import inf
from urllib import response
import yfinance as yf
from flask import Flask, request, jsonify

app = Flask(__name__)


def retrieve_from_dictionary(item, dictionary, default=None):
    if item in dictionary:
        value = dictionary[item]
        return default if value == "Infinity" else value
    else:
        return default
    
def exists(items:list, dictionary):
    return all(item in dictionary and dictionary[item] != "" for item in items)

def retrieve_items(items, dictionary):
    response = {}
    for response_key, item, default_value in items:
        response[response_key] = retrieve_from_dictionary(item, dictionary, default_value)
    return response



@app.route("/fundamental/summary", methods=["GET"])
def get_fundamental_summary():
    ticker = request.args.get("ticker")  # Get stock symbol from query parameter

    try:
        stock = yf.Ticker(ticker)
        info = stock.info

        items_to_retrieve = [
            ("Ticker", "symbol", ""),
            ("Name", "longName", ""),
            ("DividendYield", "dividendYield", 0.0),
            ("ProfitMargin", "profitMargins", 0.0),
            ("PayoutRatio", "payoutRatio", 0.0),
            ("PeForward", "forwardPE", 0.0),
            ("PriceToBook", "priceToBook", 0.0),
            ("ReturnOnEquity", "returnOnEquity", 0.0),
            ("DebtToEquity", "debtToEquity", 0.0),
            ("PriceToSales", "priceToSalesTrailing12Months", 0.0),
            ("Beta", "beta", 0.0),
            ("MarketCap", "marketCap", 0.0),
        ]

        response = retrieve_items(items_to_retrieve, info)

        return jsonify(response), 200

    except Exception as e:
        return jsonify({"error": str(e)}), 500
    
@app.route("/symbol/full", methods=["GET"])
def get_symbol_full():
    ticker = request.args.get("ticker")  # Get stock symbol from query parameter

    try:
        stock = yf.Ticker(ticker)
        info = stock.info

        items_to_retrieve = [
            ("Ticker", "symbol", ""),
            ("Name", "longName", ""),
            ("Type", "quoteType", ""),
            ("Exchange", "exchange", ""),
            ("Country", "country", ""),
            ("DividendYield", "dividendYield", 0.0),
            ("ProfitMargin", "profitMargins", 0.0),
            ("PayoutRatio", "payoutRatio", 0.0),
            ("PeForward", "forwardPE", 0.0),
            ("PriceToBook", "priceToBook", 0.0),
            ("ReturnOnEquity", "returnOnEquity", 0.0),
            ("DebtToEquity", "debtToEquity", 0.0),
            ("PriceToSales", "priceToSalesTrailing12Months", 0.0),
            ("Beta", "beta", 0.0),
            ("MarketCap", "marketCap", 0.0),
            ("Close", "previousClose", 0.0),
            ("Open", "open", 0.0),
            ("High", "dayHigh", 0.0),
            ("Low", "dayLow", 0.0),
            ("Volume", "volume", 0.0),
        ]

        response = retrieve_items(items_to_retrieve, info)
        
        return jsonify(response), 200

    except Exception as e:
        return jsonify({"error": str(e)}), 500


@app.route("/symbol/summary", methods=["GET"])
def get_symbol_summary():
    ticker = request.args.get("ticker")  # Get stock symbol from query parameter

    try:
        stock = yf.Ticker(ticker)
        info = stock.info

        if not exists(["longName", "exchange"], info):
            raise Exception("Symbol Cannot be found!")
        
        items_to_retrieve = [
            ("Ticker", "symbol", ""),
            ("Name", "longName", ""),
            ("Type", "quoteType", ""),
            ("Exchange", "exchange", ""),
            ("Country", "country", ""),
        ]
        
        response = retrieve_items(items_to_retrieve, info)
       
        return jsonify(response), 200

    except Exception as e:
        return jsonify({"error": str(e)}), 500


if __name__ == "__main__":
    app.run(debug=True, port=5247)
