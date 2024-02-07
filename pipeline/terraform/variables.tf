# Define variables
variable "location" {
  default = "East US"  # Change to your desired Azure region
}

variable "resource_group_name" {
  default = "scoreboard-rg"  # Change to your desired resource group name
}

variable "app_name" {
  default = "scoreboard"  # Change to your desired web app name
}

variable "sql_server_name" {
  default = "sqlserver"  # Change to your desired SQL server name
}

variable "sql_database_name" {
  default = "my-database"  # Change to your desired SQL database name
}

variable "admin_username" {
  default = "ruut"  # Change to your desired admin username for SQL server
}

variable "admin_password" {
  default = "18d$^*hfa&01kda1"  # Change to your desired admin password for SQL server
}