pipeline {
    agent any 

    stages {
        stage('Checkout') {
            steps {
                checkout scm
            }
        }

        stage('Build and Test') {
            steps {
                // Change 'docker-compose' to 'docker compose'
                sh 'docker compose up --build --exit-code-from tests --abort-on-container-exit'
            }
        }
    }

    post {
        always {
            // Change 'docker-compose' to 'docker compose' here too
            sh 'docker compose down'
        }
    }
}