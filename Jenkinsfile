pipeline{
agent any
environment {
    dotnet ="/usr/share/dotnet/dotnet"
    projectKey = "CharlieBackend"
    sonarUrl = "http://62.171.182.32:9000"
    sonarLogin = "15373bb1f498a29ede21cacd687bb105dec45d1f"
    sonarScanner = "/home/ec2-user/.dotnet/tools/dotnet-sonarscanner"
}

stages{
    stage ('Clean workspace') {
        steps {
            cleanWs()
        }
    }

    stage ('Git Checkout') {
        steps {
            git branch: 'dev', url: 'https://github.com/ViktorMarhitich/WhatBackend.git'
        }
    }
  
    stage ('Fill database') {
        steps {
            sh(script:'''
            mysql -uadmin -h mysqlinstance.cwkbjhl45gxq.eu-central-1.rds.amazonaws.com -padmin123 Soft < /var/lib/jenkins/workspace/whatbackend_dev/scripts/1_generate_database.sql
            mysql -uadmin -h mysqlinstance.cwkbjhl45gxq.eu-central-1.rds.amazonaws.com -padmin123 Soft < /var/lib/jenkins/workspace/whatbackend_dev/scripts/2_final_script_with_data.sql
            mysql -uadmin -h mysqlinstance.cwkbjhl45gxq.eu-central-1.rds.amazonaws.com -padmin123 Soft < /var/lib/jenkins/workspace/whatbackend_dev/scripts/3_changing_logic_for_homeworks.sql
            mysql -uadmin -h mysqlinstance.cwkbjhl45gxq.eu-central-1.rds.amazonaws.com -padmin123 Soft < /var/lib/jenkins/workspace/whatbackend_dev/scripts/4_update_data_for_homeworks.sql
            mysql -uadmin -h mysqlinstance.cwkbjhl45gxq.eu-central-1.rds.amazonaws.com -padmin123 Soft < /var/lib/jenkins/workspace/whatbackend_dev/scripts/5_adding_history_of_homeworks.sql
            mysql -uadmin -h mysqlinstance.cwkbjhl45gxq.eu-central-1.rds.amazonaws.com -padmin123 Soft < /var/lib/jenkins/workspace/whatbackend_dev/scripts/6_add_avatars.sql
            mysql -uadmin -h mysqlinstance.cwkbjhl45gxq.eu-central-1.rds.amazonaws.com -padmin123 Soft < /var/lib/jenkins/workspace/whatbackend_dev/scripts/7_add_homework_attachments.sql
            mysql -uadmin -h mysqlinstance.cwkbjhl45gxq.eu-central-1.rds.amazonaws.com -padmin123 Soft < /var/lib/jenkins/workspace/whatbackend_dev/scripts/8_add_students_homeworks.sql
            mysql -uadmin -h mysqlinstance.cwkbjhl45gxq.eu-central-1.rds.amazonaws.com -padmin123 Soft < /var/lib/jenkins/workspace/whatbackend_dev/scripts/9_add_IsActive_for_studentgroups.sql
            ''')
        }
    }
  
    stage ('Create .env files') {
        steps {
            sh '''
            cat <<EOF > /var/lib/jenkins/workspace/whatbackend_dev/CharlieBackend.Api/.env 
            ConnectionStrings__DefaultConnection=server=mysqlinstance.cwkbjhl45gxq.eu-central-1.rds.amazonaws.com;port=3306;UserId=admin;Password=admin123;database=soft;Allow User Variables=true
            ConnectionStrings__RabbitMQ=host=kangaroo.rmq.cloudamqp.com;virtualHost=cfhrvrrt;username=cfhrvrrt;password=yYvcHUcFxTsHGm51j4GtpA3mFguNv065 
            ConnectionStrings__AzureBlobsAccessKey=DefaultEndpointsProtocol=https;AccountName=csb10032000fbf86473;AccountKey=3Naz0PXXBe0Lie7HV51jdZsSFCqThDMsqGWdENueI/d2OoV14j6o9Hh0lY1TvAtM8g0VIuPQLDDmEruu951NZA==;EndpointSuffix=core.windows.net

            BotSettings__Url=https://963c-188-163-45-170.ngrok.io
            BotSettings__Key=1945675656:AAF5rVHswcwa8-xIZLS4DUlgFL2RW8mhrGM
            BotSettings__Name=whatnotification_bot

            # dev local token

            AuthOptions__KEY=mysupersecret_secretkey!123

            # email notifier account credentials

            CredentialsSendersSettings__email=WhatITAcademy@gmail.com

            CredentialsSendersSettings__password=sseta2551fgya1235
            EOF'''
          
            sh '''
            cat <<EOF > /var/lib/jenkins/workspace/whatbackend_dev/CharlieBackend.Panel/.env 
            #_____________For Admin Panel_________________

            # do not commit this file to VCS

            # Naming rule: if the path to the secret is root/preRoot/secret, then you must write your secret value as root__preRoot__secret (2 underscores)


            # devlocalhost cookies key

            Cookies__SecureKey=MyVerySecretKey
            EOF'''
        } 
    }

    stage('Restore packages') {
        steps {
            sh(script: "${dotnet} restore /var/lib/jenkins/workspace/whatbackend_dev/CharlieBackend.sln")
        } 
    }

    stage('Clean'){
        steps{
            
            sh(script: "${dotnet} clean /var/lib/jenkins/workspace/whatbackend_dev/CharlieBackend.Api/CharlieBackend.Api.csproj")
            sh(script: "${dotnet} clean /var/lib/jenkins/workspace/whatbackend_dev/CharlieBackend.Panel/CharlieBackend.Panel.csproj")
        }
    }

    stage('Build'){
        steps{
            
            sh(script: "${dotnet} build /var/lib/jenkins/workspace/whatbackend_dev/CharlieBackend.Api/CharlieBackend.Api.csproj --configuration Release")
            sh(script: "${dotnet} build /var/lib/jenkins/workspace/whatbackend_dev/CharlieBackend.Panel/CharlieBackend.Panel.csproj --configuration Release")
        }
    }

    stage('Test: Unit Test'){
        steps {
            
            sh(script: "${dotnet} test /var/lib/jenkins/workspace/whatbackend_dev/CharlieBackend.Api.UnitTes/CharlieBackend.Api.UnitTest.csproj")
        }
    }
    
    stage('Code Quality Check via SonarQube') {
        steps {
            sh "${sonarScanner} begin /k:${projectKey} /d:sonar.host.url=${sonarUrl} /d:sonar.login=${sonarLogin}"
            sh "${dotnet} build /var/lib/jenkins/workspace/whatbackend_dev/CharlieBackend.sln"
            sh "${sonarScanner} end /d:sonar.login=${sonarLogin}"
        }
    }
  }
}
