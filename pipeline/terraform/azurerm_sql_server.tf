# Define Azure SQL Server
resource "azurerm_sql_server" "scoreboard_sql_server" {
  name                         = var.sql_server_name
  resource_group_name          = azurerm_resource_group.scoreboard_rg.name
  location                     = azurerm_resource_group.scoreboard_rg.location
  version                      = "12.0"
  administrator_login          = var.admin_username
  administrator_login_password = var.admin_password
  
  tags = {
    environment = "production"
  }
}

# Define Azure SQL Database
resource "azurerm_sql_database" "scoreboard_database" {
  name                = var.sql_database_name
  resource_group_name = azurerm_resource_group.scoreboard_rg.name
  server_name         = azurerm_sql_server.scoreboard_sql_server.name
  edition             = "Standard"
  collation           = "SQL_Latin1_General_CP1_CI_AS"

  tags = {
    environment = "production"
  }
}