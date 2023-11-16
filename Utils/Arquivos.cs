using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace glasnost_back.Utils
{
    public static class Arquivos
    {
        private static CloudBlobContainer container = CloudStorageAccount
            .Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"))
            .CreateCloudBlobClient()
            .GetContainerReference("complianceonlinecontainer");


        public static async Task<string> DownloadArquivoAzureAsync(string nomeAzure, string nomeArquivo)
        {
            try
            {
                string diretorio = "";
                nomeArquivo = Path.Combine(diretorio, nomeArquivo);

                if (File.Exists(nomeArquivo))
                    File.Delete(nomeArquivo);

                CloudBlockBlob blockBlob = container.GetBlockBlobReference(nomeAzure);

                using (var memoryStream = new MemoryStream())
                {
                    await blockBlob.DownloadToStreamAsync(memoryStream);
                    File.WriteAllBytes(nomeArquivo, memoryStream.ToArray());
                    return nomeArquivo;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static async void DeleteArquivoAzure(string nomeAzure)
        {
            try
            {

                CloudBlockBlob blockBlob = container.GetBlockBlobReference(nomeAzure);
                blockBlob.DeleteIfExistsAsync();

            }
            catch (Exception e)
            {
                return;
            }
        }

        // Salva um arquivo de dentro do projeto
        public static async Task<string> SalvarArquivoAzureAsync(string appPath, string fileName)
        {
            if (string.IsNullOrEmpty(appPath) || string.IsNullOrEmpty(fileName))
                return null;

            string caminho = "";
            string FileName = Format.RemoveAccents(fileName);
            try
            {
                using (var fileStream = File.OpenRead(appPath + fileName))
                {
                    CloudBlockBlob blockBlob = container.GetBlockBlobReference(DateTime.Now.TimeOfDay + FileName);
                    await blockBlob.UploadFromStreamAsync(fileStream);
                    caminho = blockBlob.Name;
                }
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                if (File.Exists(appPath + fileName))
                    File.Delete(appPath + fileName);
            }

            return caminho;
        }



        public static async Task<string> SalvarArquivoAzureAsync(dynamic arquivo)
        {
            string caminho = "";
            string FileName = Format.RemoveAccents(arquivo.FileName);
            string physicalApplicationPath;
            try
            {
                physicalApplicationPath = "";
            }
            catch (Exception e)
            {
                try
                {
                    physicalApplicationPath = AppDomain.CurrentDomain.BaseDirectory;
                }
                catch (Exception o)
                {
                    return null;
                }
            }


            string nomeTemporario = Path.Combine(physicalApplicationPath + "App_Data\\TEMP", DateTime.Now.TimeOfDay.TotalHours + FileName);

            arquivo.SaveAs(nomeTemporario);

            try
            {
                using (var fileStream = File.OpenRead(nomeTemporario))
                {
                    CloudBlockBlob blockBlob = container.GetBlockBlobReference(DateTime.Now.TimeOfDay + Format.RemoveAccents(arquivo.FileName));
                    await blockBlob.UploadFromStreamAsync(fileStream);
                    caminho = blockBlob.Name;
                }
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                if (File.Exists(nomeTemporario))
                    File.Delete(nomeTemporario);
            }
            return caminho;
        }


    }

    public enum Arquivo_Classe
    {
        Denuncia_Relatorio,
        Denuncia_Arquivo,
        Empresa_Cronograma_Implantacao,
        Empresa_Logo,
        Treinamento_Video,
        Treinamento_Material,
        Documento,
        Documento_Anexo,
        Documento_Modelo,
        Documento_Modelo_Anexo,
        Documento_Aprovacao,
        Prospect_Arquivo,
        Pessoa_Qualificada_Certificado
    }
}
