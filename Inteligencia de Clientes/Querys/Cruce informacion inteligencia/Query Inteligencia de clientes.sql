--PORTILLO
--Query inteligencia clientes ventas junio 2016

select t0.Folio
      ,convert(nvarchar(10),t0.Fecha_Factura,105) Fecha_Factura
      ,t0.Rut_Cliente
      ,t0.Nombre_Cliente
      ,t0.Email_Cliente
      ,t0.Tel_Fijo_Cliente
      ,t0.Tel_Celular_Cliente
      ,t0.Direccion_Cliente 
from VentaAutos t0
where Empresa in ('Automotriz Portezuelo S.A.','AUTOMOTRIZ PORTILLO PIRAMIDE S.A.')
and convert(nvarchar(10),Fecha_Factura,120) between '2017-06-01' and '2017-06-31'
and t0.Estado_Venta = 'FACTURADO'









--select * from VentaAutos  