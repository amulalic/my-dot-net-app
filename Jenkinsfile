pipeline {
    agent any 

    parameters {
        choice(
            name: 'TEST_CATEGORY',
            choices: ['All', 'Smoke', 'Regression', 'Critical'],
            description: 'Select which test category to execute'
        )
    }

    stages {
        stage('Checkout') {
            steps {
                // Pulls fresh code from GitHub
                checkout scm
            }
        }

        stage('Build and Test') {
            steps {
                script {
                    // Create the filter argument
                    def testArgs = ""
                    if (params.TEST_CATEGORY != 'All') {
                        testArgs = "--filter TestCategory=${params.TEST_CATEGORY}"
                    }
                    
                    // Pass it as a variable to Docker Compose
                    sh "DYNAMIC_ARGS='${testArgs}' docker compose up --build --exit-code-from tests"
                }
            }
        }
    }

    post {
        always {
            sh 'docker compose down'
        }
    }
}