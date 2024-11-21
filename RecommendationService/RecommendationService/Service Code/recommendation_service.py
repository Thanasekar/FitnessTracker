from flask import Flask, request, jsonify
from datetime import datetime

app = Flask(__name__)

# Recommendation logic
def generate_recommendations(activity_data, health_metrics_data):
    recommendations = []

    for activity in activity_data:
        user_id = activity['UserId']
        corresponding_metrics = next(
            (metrics for metrics in health_metrics_data
             if metrics['UserId'] == user_id and metrics['Date'] == activity['Date']),
            None
        )

        if corresponding_metrics:
            recommendation = {
                "UserId": user_id,
                "RecommendationText": generate_recommendation_text(activity, corresponding_metrics)
            }
            recommendations.append(recommendation)

    return recommendations


def generate_recommendation_text(activity, metrics):
    recommendations = []

    if activity['Steps'] < 10000:
        recommendations.append(f"Increase your steps to at least 10,000. Current steps: {activity['Steps']}.")
    if activity['ExerciseMinutes'] < 30:
        recommendations.append(f"Try to exercise for at least 30 minutes. Current: {activity['ExerciseMinutes']} minutes.")
    if metrics['HeartRate'] > 100:
        recommendations.append("Your heart rate is high. Consider relaxation exercises.")
    elif metrics['HeartRate'] < 60:
        recommendations.append("Your heart rate is low. Consider consulting a physician.")
    if metrics['Calories'] < 2000:
        recommendations.append(f"Increase your calorie intake. Current calories: {metrics['Calories']}.")

    return " ".join(recommendations)


@app.route('/api/recommendations', methods=['POST'])
def get_recommendations():
    data = request.get_json()
    activity_data = data.get('activities', [])
    health_metrics_data = data.get('healthMetrics', [])

    recommendations = generate_recommendations(activity_data, health_metrics_data)
    return jsonify(recommendations)


if __name__ == '__main__':
    app.run(host='0.0.0.0', port=5002)
