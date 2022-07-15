using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coolblue_assesment.Models;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;


namespace coolblue_assesment.Data
{
    public class BulkImport
    {
        private readonly AppDbContext _context;
        private List<Product>? products {get; set;}
        private List<ProductType>? productTypes {get; set;}

        public BulkImport(AppDbContext context)
        {
            _context = context;
        }

        public bool startBulkImport(String productJsonFile ,String productTypeJsonFile)
        {
            FileStream openStreamProducts = File.OpenRead(productJsonFile);
            FileStream openStreamProductTypes = File.OpenRead(productTypeJsonFile);            

            bool resultCreateProductTypes = this.createProductTypeObjects(openStreamProductTypes);
            if (resultCreateProductTypes == false)
            {
                Console.WriteLine("ProductTypes Could not be created");
                return false;
            }

            bool resultCreateProducts = this.createProductObjects(openStreamProducts);
            if (resultCreateProducts == false)
            {
                Console.WriteLine("Products could not be created");
                return false;
            }

             if (productTypes != null){productTypes.ForEach(productType => Console.WriteLine(JsonSerializer.Serialize(productType)));}
            if (products != null){products.ForEach(product => Console.WriteLine(JsonSerializer.Serialize(product)));}   

            // _context.ProductTypes.AddRange(this.productTypes);
            _context.Products.AddRange(this.products); 
            
            _context.SaveChanges();

            //Result script

           

            return true;
        }

        private bool createProductTypeObjects(FileStream openStreamProductTypes)
        {
            this.productTypes = JsonSerializer.Deserialize<List<ProductType>>(openStreamProductTypes);

            if (this.productTypes == null || productTypes.Count < 1){return false;}

            this.productTypes.ForEach( delegate(ProductType productType) {
                if(productType != null && productType.name != null){
                    ProductTypeEnum? productTypeEnum = getProductEnumTypeByString(productType.name);
                    if (productTypeEnum == null){Console.WriteLine(productType.id + " cannot convert name to enum");}
                    productType.productTypeEnum = productTypeEnum;
                }else{
                    Console.WriteLine( "Product type or product type name is null");
                }
                
            });

            productTypes.RemoveAll(productType => productType == null);

            return true;
        }

        private ProductTypeEnum? getProductEnumTypeByString(String stringType)
        {

            ProductTypeEnum? resultEnumType = null;
            
            switch (stringType)
            {
            case "Laptops":
                resultEnumType = ProductTypeEnum.Laptops;
                break;
            case "Smartphones":
                resultEnumType = ProductTypeEnum.Smartphones;
                break;
            case "Digital cameras":
                resultEnumType = ProductTypeEnum.DigitalCameras;
                break;
            case "SLR cameras":
                resultEnumType = ProductTypeEnum.SlrCameras;
                break;
            case "MP3 players":
                resultEnumType = ProductTypeEnum.MP3Players;
                break;
            case "Washing machines":
                resultEnumType = ProductTypeEnum.WashingMachines;
                break;
            default:
                resultEnumType = null;
                break;
            }

            return resultEnumType;
        }

        public bool createProductObjects(FileStream openStreamProducts)
        {
            products = JsonSerializer.Deserialize<List<Product>>(openStreamProducts);
            if (this.products == null || products.Count < 1){return false;}

            this.products.ForEach( delegate(Product product) {
                int? productTypeId = product.productTypeId;
                if (productTypeId == null){Console.WriteLine(product.id + " Product type id is not stored in object");}

                ProductType? ProductType = this.productTypes.FirstOrDefault(productType => productType.id == productTypeId);
                if (ProductType == null)
                {
                    Console.WriteLine(productTypeId + " Could not find productType with the given Id");
                }else{
                    product.ProductType = ProductType;
                }
            });

            products.RemoveAll(product => product == null);

            return true;
        }      
    }
}