resource "azurerm_app_service_plan" "app_service_plan" {
  name                = "${var.app_name}-plan"
  location            = azurerm_resource_group.rg.location
  resource_group_name = azurerm_resource_group.rg.name
  kind                = "Linux"
  reserved            = true

  sku {
    tier = "Standard"
    size = "S1"
  }
}

# Define Azure Linux Web App
resource "azurerm_linux_web_app" "scoreboard_web_app" {
  name                = var.app_name
  location            = azurerm_resource_group.scoreboard_rg.location
  resource_group_name = azurerm_resource_group.scoreboard_rg.name
  app_service_plan_id = azurerm_app_service_plan.scoreboard_app_service_plan.id

  site_config {
    always_on                  = true
    dotnet_framework_version   = "v8.0"
    scm_type                   = "LocalGit"
    use_32_bit_worker_process = false
  }

  connection_string {
    name  = "SQLCONNSTR"
    type  = "SQLServer"
    value = "Server=tcp:${azurerm_sql_server.scoreboard_sql_server.fully_qualified_domain_name},1433;Initial Catalog=${azurerm_sql_database.scoreboard_database.name};Persist Security Info=False;User ID=${azurerm_sql_server.scoreboard_sql_server.administrator_login};Password=${azurerm_sql_server.scoreboard_sql_server.administrator_login_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
  }
}