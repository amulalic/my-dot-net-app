pipeline {
    agent any 

    stages {
        stage('Checkout') {
            steps {
                // Pulls fresh code from GitHub
                checkout scm
            }
        }

        stage('Build and Test') {
            steps {
                // Notice: No more HOST_WORKSPACE or hardcoded /Users/amulalic/ paths!
                // Since we are building the image, Docker uses the local workspace files.
                sh 'docker compose up --build --exit-code-from tests --abort-on-container-exit'
            }
        }
    }

    post {
        always {
            sh 'docker compose down'
        }
    }
}