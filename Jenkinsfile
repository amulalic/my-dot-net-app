pipeline {
    agent any 

    stages {
        stage('Checkout') {
            steps {
                // Pulls the latest code from GitHub
                checkout scm
            }
        }

        stage('Build and Test') {
            steps {
                // This command builds the app AND runs Playwright tests
                // --abort-on-container-exit ensures Jenkins knows when the tests finish
                sh 'docker-compose up --build --exit-code-from tests --abort-on-container-exit'
            }
        }
    }

    post {
        always {
            // Clean up to keep your Mac's storage clean
            sh 'docker-compose down'
        }
        success {
            echo 'Quality Check Passed!'
        }
        failure {
            echo 'Quality Check Failed. Check the logs below.'
        }
    }
}