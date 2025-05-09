import React, {useEffect, useState} from 'react';
import {useForm} from 'react-hook-form';
import logo from './logo.svg';
import './App.css';
import { error } from 'console';

interface ContactData{
  id : number;
  name : string;
  phoneNumber: string;
  emailAddress : string;
}

function ContactForm() {
  const {
    register,
    handleSubmit,
    reset,
    setValue,
    formState: { errors }
  } = useForm();

  
  const [contacts,setContacts] = useState<ContactData[]>([]);
 
  const fetchContacts = async () => {
    try {
      console.log("env=" + process.env.REACT_APP_GET_API_URL);
      const res = await fetch(process.env.REACT_APP_GET_API_URL??'')
      const data = await res.json();
      setContacts(data);
      
      
    } catch (err) {
      console.error("Error while fetching data", err);
    
    }
  };

  // Simulate GET request to populate default values (optional)
  useEffect(() => {
   fetchContacts();
  }, []);
 
  const onSubmit = async (data: any) => {
  
    try {
      const response = await fetch(process.env.REACT_APP_POST_API_URL??'', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(data)
      });
 
      if (response.ok) {
        alert('Record saved!');
        reset();
      } else {
        alert('Failed to Save Record.');
      }
    } catch (error) {
      console.error('Error:', error);
    }
  };
 
  return (
   <div>
    <h2>Contact Submission Form</h2>
    
    <div style={{width:'100%',margin:'auto',float:'left'}}>
      
      <form onSubmit={handleSubmit(onSubmit)}>
       
        <div>
          <label style={{width:'150px',float:'left',marginRight:'15px'}}>Name</label>
          <input {...register('name', { required: 'Name is required' })} />
          {errors.name && <span style={{ color: 'red' }}>
            { `${errors.name?.message}` }
            </span>
            }
      </div>

      <div>
        <label style={{width:'150px',float:'left',marginRight:'15px'}}>Email</label>
        <input
          {...register('emailAddress', {
            required: 'Email is required',
            pattern: { value: /\S+@\S+\.\S+/, message: 'Invalid email' }
          })} />
          
          {errors.emailAddress &&<span style={{ color: 'red' }}>
        {`${errors.emailAddress?.message}`}</span>}
      </div>
 
      <div>
          <label style={{width:'150px',float:'left',marginRight:'15px'}}>Phone Number</label>
          <input {...register('phoneNumber', { required: 'Phone Number is required' })} />
          {errors.phoneNumber && <span style={{ color: 'red' }}>
            { `${errors.phoneNumber?.message}` }
            </span>
            }
        </div>
        
        <button type="submit">Send</button>
    </form>
    </div>
  


    <div style={{width:'100%',margin:'auto',float:'left'}}>
    <h2>Contact Data</h2>
      <table style={{width:'100%',borderCollapse:'collapse'}}>
        
        <thead>
        <tr>
          <th style={{border:'1px solid #ddd',padding:'8px'}}>Name</th>
          <th style={{border:'1px solid #ddd',padding:'8px'}}>Phone Number</th>
          <th style={{border:'1px solid #ddd',padding:'8px'}}>Email Address</th>
          </tr>
        </thead>
        
       {contacts ? <tbody>
        {contacts.map((contact, index) => (

       
          <tr key={index}>
          
          <td style={{border:'1px solid #ddd',padding:'8px'}}>{contact.name}</td>
          <td style={{border:'1px solid #ddd',padding:'8px'}}>{contact.phoneNumber}</td>
          <td style={{border:'1px solid #ddd',padding:'8px'}}>{contact.emailAddress}</td>
          </tr>
        ))}
        </tbody> : null
        }
      </table>
    </div>
    </div>

  );
}
 
export default ContactForm;