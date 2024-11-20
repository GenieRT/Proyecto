﻿using ProyectoIntegradorLibreria.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIntegradorLogicaAplicacion.DTOs
{
    public class LineaPedidoDTO
    {
        public int ProductoId { get; set; }

        public ProductoDTO? Producto { get; set; }
        public PresentacionDTO? Presentacion { get; set; }

        public int PresentacionId { get; set; }
        public int Cantidad { get; set; }

        public PedidoDTO? Pedido { get; set; }

        public int PedidoId { get; set; }

        public LineaPedidoDTO(LineaPedido linea)
        {
            this.ProductoId = linea.ProductoId;
            this.Producto = new ProductoDTO(linea.Producto);
            this.PresentacionId = linea.PresentacionId;
            this.Presentacion = new PresentacionDTO(linea.Presentacion); 
            this.Cantidad = linea.Cantidad;
            this.PedidoId = linea.PedidoId;
            this.Pedido = linea.Pedido != null ? new PedidoDTO(linea.Pedido) : null; 
        }


        public LineaPedidoDTO() { }
    }
}   
