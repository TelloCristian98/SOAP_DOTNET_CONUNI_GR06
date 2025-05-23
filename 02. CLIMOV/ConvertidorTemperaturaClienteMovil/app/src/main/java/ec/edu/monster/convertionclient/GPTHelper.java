

package ec.edu.monster.convertionclient;
//------------------------------------------------------------------------
//
// Generated by www.easywsdl.com
// Version: 9.3.3.2
//
// Created by Quasar Development 
//
// This class has been generated for test purposes only and cannot be used in any commercial project.
// To use it in commercial project, you need to generate this class again with Premium account.
// Check https://EasyWsdl.com/Payment/PremiumAccountDetails to see all benefits of Premium account.
//
// Licence: D66AF282617D7256703FC8C79B671C10E55882BDBDD2F1B85551AFA94EE2CBD134FEC923F8BE0242192286A9E41768C2D17AAA3E8C7DAF3C21EC8B1E9EA5BAFA
//------------------------------------------------------------------------
import org.xml.sax.SAXException;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.io.Reader;
import java.io.StringWriter;
import java.nio.charset.StandardCharsets;

import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.transform.TransformerException;
import javax.xml.transform.TransformerFactory;
import javax.xml.transform.Transformer;
import javax.xml.transform.dom.DOMSource;
import javax.xml.transform.stream.StreamResult;
import javax.xml.parsers.ParserConfigurationException;

public class GPTHelper
{
    public static final String MS_SERIALIZATION_NS = "http://schemas.microsoft.com/2003/10/Serialization/";
    public static final String XSI = "http://www.w3.org/2001/XMLSchema-instance";
    public static final String XML = "http://www.w3.org/XML/1998/namespace";
    public static final String XMLNS  = "http://www.w3.org/2000/xmlns/";

    public static String getStringFromDocument(org.w3c.dom.Document doc)
    {
        try
        {
            DOMSource domSource = new DOMSource(doc);
            StringWriter writer = new StringWriter();
            StreamResult result = new StreamResult(writer);
            TransformerFactory tf = TransformerFactory.newInstance();
            Transformer transformer = tf.newTransformer();
            transformer.transform(domSource, result);
            return writer.toString();
        }
        catch (TransformerException ex)
        {
            ex.printStackTrace();
            return null;
        }
    }
    
    public static org.w3c.dom.Document loadXMLFromString(String xml) throws ParserConfigurationException, IOException, SAXException
    {
        DocumentBuilderFactory factory = DocumentBuilderFactory.newInstance();
        factory.setNamespaceAware(true);
        DocumentBuilder builder = factory.newDocumentBuilder();
        return builder.parse(new ByteArrayInputStream(xml.getBytes(StandardCharsets.UTF_8)));
    }

    public static org.w3c.dom.Element getElement(org.w3c.dom.Element xml,String namespace,String name)
    {
        org.w3c.dom.NodeList nodes=xml.getElementsByTagNameNS(namespace,name);
        if(nodes.getLength()>0)
        {
            return (org.w3c.dom.Element)nodes.item(0);
        }
        return null;
    }

    public static org.w3c.dom.Element getFirstChildElement(org.w3c.dom.Element root)
    {
        org.w3c.dom.Node child = root.getFirstChild();
        while (child != null) {
            if (child.getNodeType() == org.w3c.dom.Node.ELEMENT_NODE)
            {
                return (org.w3c.dom.Element)child;
            }
            child = child.getNextSibling();
        }

        return null;
    }

    public static boolean isEmpty(CharSequence str)
    {
        return str == null || str.length() == 0;
    }

    public static boolean isValue(org.w3c.dom.Element node, String name)
    {
        if(node==null)
        {
            return false;
        }
        if(node.getLocalName().equals(name))
        {
            String nil=node.getAttributeNS(XSI,"nil");
            return isEmpty(nil);
        }
        return true;
    }

    public static org.w3c.dom.Node getResult( org.w3c.dom.Element body, String name, boolean isAttribute)
    {
        org.w3c.dom.Element resultElement=getFirstChildElement(body);
        if(resultElement!=null)
        {
            org.w3c.dom.Element propertyElement = getFirstChildElement(resultElement);
            if(propertyElement!=null)
            {
                if(isAttribute)
                {
                    org.w3c.dom.Attr attrNode= propertyElement.getAttributeNode(name);
                    if(attrNode!=null)
                    {
                        return attrNode;
                    }
                }
                else
                {
                    if(propertyElement.getLocalName().equals(name))
                    {
                        return propertyElement;
                    }
                }
            }
        }

        if(isAttribute)
        {
            org.w3c.dom.Attr attrNode= resultElement.getAttributeNode(name);
            if(attrNode!=null)
            {
                return attrNode;
            }
        }
        else if(resultElement.getLocalName().equals(name))
        {
            return resultElement;
        }

        return null;
    }

    public static boolean toBoolFromString(String str)
    {
        return str.equals("True") || str.equals("true") || str.equals("yes") || str.equals("1");
    }

    public static boolean hasValue(org.w3c.dom.Element node, String name)
    {
        if(node==null)
        {
            return false;
        }
        org.w3c.dom.Element child=getNodeByLocalName( node, name, 0);
        if (child != null)
        {
            String nilAttr=child.getAttributeNS(XSI,"nil");
            return isEmpty(nilAttr);
        }
        return false;
    }

    public static org.w3c.dom.Element getNodeByLocalName(org.w3c.dom.Element node,String name,int index)
    {
        org.w3c.dom.NodeList children=node.getElementsByTagNameNS("*",name);
        if(children.getLength()>0)
        {
            return (org.w3c.dom.Element)children.item(index);
        }
        return null;
    }

    public static String streamToString(InputStream stream) throws IOException 
    {
        int bufferSize = 1024;
        char[] buffer = new char[bufferSize];
        StringBuilder out = new StringBuilder();
        Reader in = new InputStreamReader(stream, StandardCharsets.UTF_8);
        for (int numRead; (numRead = in.read(buffer, 0, buffer.length)) > 0; ) {
            out.append(buffer, 0, numRead);
        }
        return out.toString();
    }

    public static void copy(InputStream source, OutputStream target) throws IOException
    {
        byte[] buf = new byte[8192];
        int length;
        while ((length = source.read(buf)) != -1) {
            target.write(buf, 0, length);
        }
    }
}