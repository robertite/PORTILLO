
select t0.EMPRESA
      ,replace(t0.FOLIO,'.','') 'Folio Comercial'
      ,replace(t0.[NRO#FACTURA],'.','') 'Factura Comercial'
      ,t1.folionum 'Factura SAP 1'
      ,t3.folionum 'Factura SAP 2'
      ,convert(nvarchar(10),t0.FECHA,105) 'Fecha Comercial'
      ,CONVERT(nvarchar(10),t1.taxdate,105) 'Fecha SAP 1'
      ,CONVERT(nvarchar(10),t3.taxdate,105) 'Fecha SAP 2'
      ,t2.idfolio 'Folio CDO'
      ,t0.ESTADO 'Estado Comercial'
      ,t2.idestado 'Estado CDO'
      
from baseventas t0

inner join [10.10.60.14].[SBO_CD1].[DBO].[OINV] t1 
          on REPLACE(t0.[NRO#FACTURA],'.','') = t1.folionum
          
inner join [10.10.60.14].[VENTASAUTOS].[DBO].[HOJANEGOCIOS] t2 
          on replace(t0.FOLIO,'.','') = t2.idFolio

outer apply ( select * from [10.10.60.14].[SBO_CD1].[DBO].[OINV] m0 
              where m0.folionum = t2.hnefacturaventa 
              and t1.folionum is null) t3
         
          
where t0.EMPRESA = 'AUTOMOTRIZ PORTILLO'
and t0.ESTADO = 'FACTURADO'
and t0.NRO#FACTURA = '158.280'

union all


select t0.EMPRESA
      ,replace(t0.FOLIO,'.','') 'Folio Comercial'
      ,replace(t0.[NRO#FACTURA],'.','') 'Factura Comercial'
      ,t1.folionum 'Factura SAP 1'
      ,t3.folionum 'Factura SAP 2'
      ,convert(nvarchar(10),t0.FECHA,105) 'Fecha Comercial'
      ,CONVERT(nvarchar(10),t1.taxdate,105) 'Fecha SAP 1'
      ,CONVERT(nvarchar(10),t3.taxdate,105) 'Fecha SAP 2'
      ,t2.idfolio 'Folio CDO'
      ,t0.ESTADO 'Estado Comercial'
      ,t2.idestado 'Estado CDO'
      
from baseventas t0

inner join [10.10.60.12].[SBO_CD1].[DBO].[OINV] t1 
          on REPLACE(t0.[NRO#FACTURA],'.','') = t1.folionum
          
          
inner join [10.10.60.12].[VENTASAUTOS].[DBO].[HOJANEGOCIOS] t2 
          on replace(t0.FOLIO,'.','') = t2.idFolio

outer apply ( select * from [10.10.60.12].[SBO_CD1].[DBO].[OINV] m0 
              where m0.folionum = t2.hnefacturaventa 
              and t1.folionum is null) t3
         
          
where t0.EMPRESA = 'Automotriz Portezuelo S.A.'
and t0.ESTADO = 'FACTURADO'

and t0.NRO#FACTURA = '158.280'



--and convert(nvarchar(10),t1.taxdate,105) between '01-06-2017' and '30-06-2017'



--select distinct * 
--from BaseVentas 
--where  ESTADO = 'FACTURADO'
--and EMPRESA = 'Automotriz Portezuelo S.A.'
--and FOLIO is NOT null
--ORDER BY FOLIO
--select distinct * 
--from BaseVentas 
--where ESTADO = 'FACTURADO'
--and EMPRESA is null





--select distinct * from BaseVentas where ESTADO = 'FACTURADO'