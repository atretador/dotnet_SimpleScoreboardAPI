# Define variables
variable "location" {
  default = "East US"  # Change to your desired Azure region
}

variable "resource_group_name" {
  default = "my-resource-group"  # Change to your desired resource group name
}

variable "app_name" {
  default = "my-web-app"  # Change to your desired web app name
}

variable "sql_server_name" {
  default = "my-sql-server"  # Change to your desired SQL server name
}

variable "sql_database_name" {
  default = "my-database"  # Change to your desired SQL database name
}

variable "admin_username" {
  default = "adminuser"  # Change to your desired admin username for SQL server
}

variable "admin_password" {
  default = "Password123!"  # Change to your desired admin password for SQL server
}