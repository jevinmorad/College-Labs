'use client';

import { motion } from 'framer-motion';
import { FiGithub } from 'react-icons/fi';

export default function SystemArchitecture() {
  return (
    <section className='py-20 px-4'>
      <div className='max-w-6xl mx-auto'>
        <motion.h2
          initial={{ opacity: 0 }}
          whileInView={{ opacity: 1 }}
          viewport={{ once: true }}
          className='text-3xl font-bold mb-12 text-center'
        >
          Project Architectures
        </motion.h2>

        <div className='grid grid-cols-1 gap-8'>
          {[
            {
              title: 'Saathi Matrimonial App',
              githubUrl: 'https://github.com/jevinmorad/saathi',
              description:
                'A Flutter-based matrimonial application with real-time matching and chat functionality',
              details: [
                'Implemented Firebase authentication for secure user access',
                'Designed responsive UI with Flutter widgets',
                'Integrated real-time database with Firebase Firestore',
                'Developed matching algorithm based on user preferences',
              ],
              tech: [
                'Flutter',
                'Dart',
                'Firebase',
                'Firestore',
                'Provider',
                'Google Maps API',
              ],
            },
            {
              title: 'BookYourCinema',
              githubUrl: 'https://github.com/jevinmorad/BookYourCinema',
              description:
                'A full-stack movie ticket booking system with admin panel',
              details: [
                'Built RESTful API with Node.js and Express',
                'Implemented JWT authentication for secure transactions',
                'Designed responsive frontend with React.js',
                'Created admin dashboard for theater management',
              ],
              tech: ['React', 'Node.js', 'Express', 'MongoDB', 'JWT', 'Redux'],
            },
          ].map((project, index) => (
            <motion.div
              key={index}
              initial={{ opacity: 0, y: 20 }}
              whileInView={{ opacity: 1, y: 0 }}
              viewport={{ once: true }}
              transition={{ delay: index * 0.2 }}
              className='bg-gray-900/50 rounded-xl p-6 backdrop-blur-sm border border-gray-800'
            >
              <div className='flex items-center justify-between'>
                <h3 className='text-2xl font-bold mb-4'>{project.title}</h3>
                <a
                  href={project.githubUrl}
                  target='_blank'
                  rel='noopener noreferrer'
                  className='text-gray-300 hover:text-white transition-colors'
                  aria-label={`View ${project.title} on GitHub`}
                >
                  <FiGithub className='w-6 h-6' />
                </a>
              </div>
              <p className='text-gray-400 mb-6'>{project.description}</p>
              <div className='mb-6'>
                <h4 className='text-lg font-semibold mb-2'>Key Features:</h4>
                <ul className='list-disc list-inside space-y-2 text-gray-300'>
                  {project.details.map((detail, i) => (
                    <li key={i}>{detail}</li>
                  ))}
                </ul>
              </div>
              <div className='flex flex-wrap gap-2'>
                {project.tech.map((tech, i) => (
                  <span
                    key={i}
                    className='text-sm px-3 py-1 bg-blue-500/10 rounded-full border border-blue-500/20'
                  >
                    {tech}
                  </span>
                ))}
              </div>
            </motion.div>
          ))}
        </div>
      </div>
    </section>
  );
}
