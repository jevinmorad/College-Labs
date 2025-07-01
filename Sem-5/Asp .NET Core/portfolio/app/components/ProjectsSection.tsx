'use client';

import { motion } from 'framer-motion';

export default function ProjectsSection() {
  return (
    <section className='py-20 px-4'>
      <div className='max-w-6xl mx-auto'>
        <motion.h2
          initial={{ opacity: 0 }}
          whileInView={{ opacity: 1 }}
          viewport={{ once: true }}
          className='text-3xl font-bold mb-16 text-center text-gray-900'
        >
          Full Stack Projects
        </motion.h2>

        <div className='space-y-16'>
          {/* Matrimonial App */}
          <motion.div
            initial={{ opacity: 0, y: 20 }}
            whileInView={{ opacity: 1, y: 0 }}
            viewport={{ once: true }}
            className='bg-white rounded-xl overflow-hidden border border-gray-200 shadow-lg'
          >
            <div className='p-8'>
              <div className='grid grid-cols-1 lg:grid-cols-2 gap-8'>
                <div className='space-y-6'>
                  <div>
                    <h3 className='text-2xl font-bold mb-4 text-gray-900'>
                      <a
                        href='https://github.com/jevinmorad/saathi'
                        target='blank'
                      >
                        Matrimonial Matchmaking App
                      </a>
                    </h3>
                    <p className='text-gray-600'>
                      A cross-platform matrimonial application built with
                      Flutter that connects potential partners with advanced
                      matching algorithms and secure communication.
                    </p>
                  </div>

                  <div className='grid grid-cols-2 gap-6'>
                    <div>
                      <h4 className='text-sm font-semibold text-blue-600 mb-3'>
                        Mobile Features
                      </h4>
                      <ul className='space-y-2 text-sm text-gray-600'>
                        <li>• Flutter cross-platform app</li>
                        <li>• Customizable user profiles</li>
                        <li>• Advanced search filters</li>
                        <li>• Real-time messaging</li>
                        <li>• Photo verification system</li>
                      </ul>
                    </div>
                    <div>
                      <h4 className='text-sm font-semibold text-purple-600 mb-3'>
                        Backend Systems
                      </h4>
                      <ul className='space-y-2 text-sm text-gray-600'>
                        <li>• Firebase Authentication</li>
                        <li>• Cloud Firestore database</li>
                        <li>• Node.js matching service</li>
                        <li>• Image storage with Cloudinary</li>
                        <li>• Push notifications</li>
                      </ul>
                    </div>
                  </div>

                  <div className='space-y-3'>
                    <h4 className='text-sm font-semibold text-teal-600'>
                      Key Achievements
                    </h4>
                    <ul className='space-y-2 text-sm text-gray-600'>
                      <li>• 95% code reuse between iOS/Android</li>
                      <li>• 200ms response time for matches</li>
                      <li>• 50% reduction in development time</li>
                      <li>• 4.8/5 average app store rating</li>
                    </ul>
                  </div>
                </div>

                <div className='bg-gray-50 rounded-xl p-6'>
                  <h4 className='text-sm font-semibold text-gray-600 mb-4'>
                    System Architecture
                  </h4>
                  <div className='aspect-[4/3] bg-white rounded-lg p-4 shadow-inner'>
                    <svg className='w-full h-full' viewBox='0 0 400 300'>
                      {/* Client Layer */}
                      <g>
                        <rect
                          x='20'
                          y='20'
                          width='170'
                          height='40'
                          rx='4'
                          className='fill-blue-100 stroke-blue-400'
                          strokeWidth='1'
                        />
                        <rect
                          x='210'
                          y='20'
                          width='170'
                          height='40'
                          rx='4'
                          className='fill-blue-100 stroke-blue-400'
                          strokeWidth='1'
                        />
                        <text
                          x='105'
                          y='45'
                          textAnchor='middle'
                          className='fill-gray-600 text-[12px]'
                        >
                          iOS App
                        </text>
                        <text
                          x='295'
                          y='45'
                          textAnchor='middle'
                          className='fill-gray-600 text-[12px]'
                        >
                          Android App
                        </text>
                      </g>

                      {/* Firebase Layer */}
                      <g>
                        <rect
                          x='20'
                          y='80'
                          width='360'
                          height='40'
                          rx='4'
                          className='fill-purple-100 stroke-purple-400'
                          strokeWidth='1'
                        />
                        <text
                          x='200'
                          y='105'
                          textAnchor='middle'
                          className='fill-gray-600 text-[12px]'
                        >
                          Firebase Services (Auth, Firestore)
                        </text>
                      </g>

                      {/* Services Layer */}
                      <g>
                        <rect
                          x='20'
                          y='140'
                          width='170'
                          height='40'
                          rx='4'
                          className='fill-teal-100 stroke-teal-400'
                          strokeWidth='1'
                        />
                        <rect
                          x='210'
                          y='140'
                          width='170'
                          height='40'
                          rx='4'
                          className='fill-teal-100 stroke-teal-400'
                          strokeWidth='1'
                        />
                        <text
                          x='105'
                          y='165'
                          textAnchor='middle'
                          className='fill-gray-600 text-[12px]'
                        >
                          Matching Algorithm
                        </text>
                        <text
                          x='295'
                          y='165'
                          textAnchor='middle'
                          className='fill-gray-600 text-[12px]'
                        >
                          Notification Service
                        </text>
                      </g>

                      {/* Storage Layer */}
                      <g>
                        <rect
                          x='20'
                          y='200'
                          width='170'
                          height='40'
                          rx='4'
                          className='fill-blue-100 stroke-blue-400'
                          strokeWidth='1'
                        />
                        <rect
                          x='210'
                          y='200'
                          width='170'
                          height='40'
                          rx='4'
                          className='fill-purple-100 stroke-purple-400'
                          strokeWidth='1'
                        />
                        <text
                          x='105'
                          y='225'
                          textAnchor='middle'
                          className='fill-gray-600 text-[12px]'
                        >
                          Cloudinary Storage
                        </text>
                        <text
                          x='295'
                          y='225'
                          textAnchor='middle'
                          className='fill-gray-600 text-[12px]'
                        >
                          User Data Cache
                        </text>
                      </g>

                      {/* Admin Layer */}
                      <g>
                        <rect
                          x='20'
                          y='260'
                          width='360'
                          height='30'
                          rx='4'
                          className='fill-teal-100 stroke-teal-400'
                          strokeWidth='1'
                        />
                        <text
                          x='200'
                          y='280'
                          textAnchor='middle'
                          className='fill-gray-600 text-[12px]'
                        >
                          Admin Dashboard (Web)
                        </text>
                      </g>

                      {/* Connection Lines */}
                      <g className='stroke-gray-400' strokeWidth='1'>
                        <line x1='105' y1='60' x2='105' y2='80' />
                        <line x1='295' y1='60' x2='295' y2='80' />
                        <line x1='105' y1='120' x2='105' y2='140' />
                        <line x1='295' y1='120' x2='295' y2='140' />
                        <line x1='105' y1='180' x2='105' y2='200' />
                        <line x1='295' y1='180' x2='295' y2='200' />
                        <line x1='200' y1='240' x2='200' y2='260' />
                      </g>
                    </svg>
                  </div>
                </div>
              </div>
            </div>
          </motion.div>

          {/* Movie Booking Platform */}
          <motion.div
            initial={{ opacity: 0, y: 20 }}
            whileInView={{ opacity: 1, y: 0 }}
            viewport={{ once: true }}
            className='bg-white rounded-xl overflow-hidden border border-gray-200 shadow-lg'
          >
            <div className='p-8'>
              <div className='grid grid-cols-1 lg:grid-cols-2 gap-8'>
                <div className='space-y-6'>
                  <div>
                    <h3 className='text-2xl font-bold mb-4 text-gray-900'>
                      <a
                        href='https://github.com/jevinmorad/BookYourCinema'
                        target='blank'
                      >
                        BookYourCinema - Movie Booking Platform
                      </a>
                    </h3>
                    <p className='text-gray-600'>
                      A full-stack movie ticket booking platform with seat
                      selection, payment processing, and admin dashboard for
                      theater management.
                    </p>
                  </div>

                  <div className='grid grid-cols-2 gap-6'>
                    <div>
                      <h4 className='text-sm font-semibold text-blue-600 mb-3'>
                        Frontend Tech
                      </h4>
                      <ul className='space-y-2 text-sm text-gray-600'>
                        <li>• React with Material UI</li>
                        <li>• Redux for state management</li>
                        <li>• Interactive seat selection</li>
                        <li>• Responsive design</li>
                      </ul>
                    </div>
                    <div>
                      <h4 className='text-sm font-semibold text-purple-600 mb-3'>
                        Backend Tech
                      </h4>
                      <ul className='space-y-2 text-sm text-gray-600'>
                        <li>• Node.js with Express</li>
                        <li>• MongoDB with Mongoose</li>
                        <li>• Razorpay payment integration</li>
                        <li>• JWT authentication</li>
                      </ul>
                    </div>
                  </div>

                  <div className='space-y-3'>
                    <h4 className='text-sm font-semibold text-teal-600'>
                      Key Features
                    </h4>
                    <ul className='space-y-2 text-sm text-gray-600'>
                      <li>• Real-time seat availability</li>
                      <li>• Secure payment processing</li>
                      <li>• Admin dashboard for theaters</li>
                      <li>• User booking history</li>
                      <li>• Email ticket confirmation</li>
                    </ul>
                  </div>
                </div>

                <div className='bg-gray-50 rounded-xl p-6'>
                  <h4 className='text-sm font-semibold text-gray-600 mb-4'>
                    System Architecture
                  </h4>
                  <div className='aspect-[4/3] bg-white rounded-lg p-4 shadow-inner'>
                    <svg className='w-full h-full' viewBox='0 0 400 300'>
                      {/* Client Layer */}
                      <g>
                        <rect
                          x='20'
                          y='20'
                          width='170'
                          height='40'
                          rx='4'
                          className='fill-blue-100 stroke-blue-400'
                          strokeWidth='1'
                        />
                        <rect
                          x='210'
                          y='20'
                          width='170'
                          height='40'
                          rx='4'
                          className='fill-blue-100 stroke-blue-400'
                          strokeWidth='1'
                        />
                        <text
                          x='105'
                          y='45'
                          textAnchor='middle'
                          className='fill-gray-600 text-[12px]'
                        >
                          User Frontend
                        </text>
                        <text
                          x='295'
                          y='45'
                          textAnchor='middle'
                          className='fill-gray-600 text-[12px]'
                        >
                          Admin Dashboard
                        </text>
                      </g>

                      {/* API Layer */}
                      <g>
                        <rect
                          x='20'
                          y='80'
                          width='360'
                          height='40'
                          rx='4'
                          className='fill-purple-100 stroke-purple-400'
                          strokeWidth='1'
                        />
                        <text
                          x='200'
                          y='105'
                          textAnchor='middle'
                          className='fill-gray-600 text-[12px]'
                        >
                          Express API Server
                        </text>
                      </g>

                      {/* Services Layer */}
                      <g>
                        <rect
                          x='20'
                          y='140'
                          width='110'
                          height='40'
                          rx='4'
                          className='fill-teal-100 stroke-teal-400'
                          strokeWidth='1'
                        />
                        <rect
                          x='145'
                          y='140'
                          width='110'
                          height='40'
                          rx='4'
                          className='fill-teal-100 stroke-teal-400'
                          strokeWidth='1'
                        />
                        <rect
                          x='270'
                          y='140'
                          width='110'
                          height='40'
                          rx='4'
                          className='fill-teal-100 stroke-teal-400'
                          strokeWidth='1'
                        />
                        <text
                          x='75'
                          y='165'
                          textAnchor='middle'
                          className='fill-gray-600 text-[12px]'
                        >
                          Auth Service
                        </text>
                        <text
                          x='200'
                          y='165'
                          textAnchor='middle'
                          className='fill-gray-600 text-[12px]'
                        >
                          Booking Service
                        </text>
                        <text
                          x='325'
                          y='165'
                          textAnchor='middle'
                          className='fill-gray-600 text-[12px]'
                        >
                          Payment Service
                        </text>
                      </g>

                      {/* Database Layer */}
                      <g>
                        <rect
                          x='20'
                          y='210'
                          width='360'
                          height='40'
                          rx='4'
                          className='fill-blue-100 stroke-blue-400'
                          strokeWidth='1'
                        />
                        <text
                          x='200'
                          y='235'
                          textAnchor='middle'
                          className='fill-gray-600 text-[12px]'
                        >
                          MongoDB Database
                        </text>
                      </g>

                      {/* External Services */}
                      <g>
                        <rect
                          x='20'
                          y='270'
                          width='170'
                          height='20'
                          rx='4'
                          className='fill-purple-100 stroke-purple-400'
                          strokeWidth='1'
                        />
                        <rect
                          x='210'
                          y='270'
                          width='170'
                          height='20'
                          rx='4'
                          className='fill-purple-100 stroke-purple-400'
                          strokeWidth='1'
                        />
                        <text
                          x='105'
                          y='285'
                          textAnchor='middle'
                          className='fill-gray-600 text-[10px]'
                        >
                          Razorpay API
                        </text>
                        <text
                          x='295'
                          y='285'
                          textAnchor='middle'
                          className='fill-gray-600 text-[10px]'
                        >
                          Email Service
                        </text>
                      </g>

                      {/* Connection Lines */}
                      <g className='stroke-gray-400' strokeWidth='1'>
                        <line x1='105' y1='60' x2='105' y2='80' />
                        <line x1='295' y1='60' x2='295' y2='80' />
                        <line x1='75' y1='120' x2='75' y2='140' />
                        <line x1='200' y1='120' x2='200' y2='140' />
                        <line x1='325' y1='120' x2='325' y2='140' />
                        <line x1='200' y1='180' x2='200' y2='210' />
                        <line x1='105' y1='250' x2='105' y2='270' />
                        <line x1='295' y1='250' x2='295' y2='270' />
                      </g>
                    </svg>
                  </div>
                </div>
              </div>
            </div>
          </motion.div>
        </div>
      </div>
    </section>
  );
}
