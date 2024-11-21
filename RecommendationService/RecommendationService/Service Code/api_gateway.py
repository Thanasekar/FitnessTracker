from flask import Flask, request, jsonify
import requests

app = Flask(__name__)

# Routes traffic to Recommendation Service
@app.route('/recommend', methods=['POST'])
def recommend():
    # Forward the request to the Recommendation Service
    url = "http://localhost:5002/api/recommendations"
    response = requests.post(url, json=request.get_json())
    return jsonify(response.json()), response.status_code


if __name__ == '__main__':
    app.run(host='0.0.0.0', port=5000)
